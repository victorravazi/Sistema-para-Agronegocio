using System;
using System.Windows.Forms;
using AgroSistema.Models;
using AgroSistema.Repositories;

namespace AgroSistema.Forms
{
    public partial class FormColheita : Form
    {
        private readonly RepositorioColheita _repo = new RepositorioColheita();
        private readonly RepositorioFazenda _repoFaz = new RepositorioFazenda();
        private readonly RepositorioCultura _repoCult = new RepositorioCultura();
        private int _idSelecionado = 0;

        public FormColheita()
        {
            InitializeComponent();
        }

        private void FormColheita_Load(object sender, EventArgs e)
        {
            CarregarComboFazendas();
            CarregarComboCulturas();
            CarregarLista();
        }

        private void CarregarComboFazendas()
        {
            try
            {
                var fazendas = _repoFaz.ListarTodos();
                cboFazenda.DataSource = fazendas;
                cboFazenda.DisplayMember = "Nome";
                cboFazenda.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar fazendas: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarComboCulturas()
        {
            try
            {
                var culturas = _repoCult.ListarTodos();
                cboCultura.DataSource = culturas;
                cboCultura.DisplayMember = "Nome";
                cboCultura.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar culturas: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarLista()
        {
            try
            {
                listBoxColheitas.DataSource = null;
                listBoxColheitas.DataSource = _repo.ListarTodos();
                listBoxColheitas.DisplayMember = "ToString";
                listBoxColheitas.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar colheitas: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listBoxColheitas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxColheitas.SelectedItem is Colheita c)
            {
                _idSelecionado = c.Id;
                dtpPlantio.Value = c.DataPlantio;
                dtpColheita.Value = c.DataColheita ?? DateTime.Today;
                chkColhido.Checked = c.DataColheita.HasValue;
                txtToneladas.Text = c.QuantidadeToneladas?.ToString("F3") ?? "";
                txtObservacoes.Text = c.Observacoes ?? "";

                foreach (Fazenda faz in cboFazenda.Items)
                    if (faz.Id == c.FazendaId) { cboFazenda.SelectedItem = faz; break; }

                foreach (Cultura cult in cboCultura.Items)
                    if (cult.Id == c.CulturaId) { cboCultura.SelectedItem = cult; break; }
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboFazenda.SelectedItem == null)
                { MessageBox.Show("Selecione a Fazenda.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

                if (cboCultura.SelectedItem == null)
                { MessageBox.Show("Selecione a Cultura.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

                decimal? toneladas = null;
                if (!string.IsNullOrWhiteSpace(txtToneladas.Text))
                {
                    if (!decimal.TryParse(txtToneladas.Text, out decimal ton) || ton < 0)
                    { MessageBox.Show("Quantidade de toneladas inválida.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                    toneladas = ton;
                }

                var colheita = new Colheita
                {
                    Id = _idSelecionado,
                    FazendaId = ((Fazenda)cboFazenda.SelectedItem).Id,
                    CulturaId = ((Cultura)cboCultura.SelectedItem).Id,
                    DataPlantio = dtpPlantio.Value.Date,
                    DataColheita = chkColhido.Checked ? dtpColheita.Value.Date : (DateTime?)null,
                    QuantidadeToneladas = toneladas,
                    Observacoes = txtObservacoes.Text.Trim()
                };

                if (_idSelecionado == 0)
                    _repo.Inserir(colheita);
                else
                    _repo.Editar(colheita);

                MessageBox.Show("Salvo com sucesso!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparCampos();
                CarregarLista();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (_idSelecionado == 0)
            { MessageBox.Show("Selecione uma colheita.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            if (MessageBox.Show("Excluir este registro?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    _repo.Deletar(_idSelecionado);
                    LimparCampos();
                    CarregarLista();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao excluir: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnNovo_Click(object sender, EventArgs e) => LimparCampos();

        private void chkColhido_CheckedChanged(object sender, EventArgs e)
        {
            dtpColheita.Enabled = chkColhido.Checked;
            txtToneladas.Enabled = chkColhido.Checked;
        }

        private void LimparCampos()
        {
            _idSelecionado = 0;
            dtpPlantio.Value = DateTime.Today;
            dtpColheita.Value = DateTime.Today;
            chkColhido.Checked = false;
            txtToneladas.Text = "";
            txtObservacoes.Text = "";
            if (cboFazenda.Items.Count > 0) cboFazenda.SelectedIndex = 0;
            if (cboCultura.Items.Count > 0) cboCultura.SelectedIndex = 0;
            listBoxColheitas.ClearSelected();
        }
    }
}
