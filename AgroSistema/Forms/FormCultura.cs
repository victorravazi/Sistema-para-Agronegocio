using System;
using System.Windows.Forms;
using AgroSistema.Models;
using AgroSistema.Repositories;

namespace AgroSistema.Forms
{
    public partial class FormCultura : Form
    {
        private readonly RepositorioCultura _repo = new RepositorioCultura();
        private int _idSelecionado = 0;

        public FormCultura()
        {
            InitializeComponent();
        }

        private void FormCultura_Load(object sender, EventArgs e)
        {
            CarregarComboTipo();
            CarregarLista();
        }

        private void CarregarComboTipo()
        {
            cboTipo.Items.Clear();
            cboTipo.Items.AddRange(new string[] { "Grão", "Hortaliça", "Fruta", "Safrinha", "Permanente", "Olerícola", "Fibra" });
        }

        private void CarregarLista()
        {
            try
            {
                listBoxCulturas.DataSource = null;
                listBoxCulturas.DataSource = _repo.ListarTodos();
                listBoxCulturas.DisplayMember = "Nome";
                listBoxCulturas.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar culturas: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listBoxCulturas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxCulturas.SelectedItem is Cultura c)
            {
                _idSelecionado = c.Id;
                txtNome.Text = c.Nome;
                cboTipo.Text = c.Tipo;
                txtTempo.Text = c.TempoMedioColheitaDias.ToString();
                txtDescricao.Text = c.Descricao;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNome.Text))
                { MessageBox.Show("Preencha o Nome.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

                if (cboTipo.SelectedItem == null && string.IsNullOrWhiteSpace(cboTipo.Text))
                { MessageBox.Show("Selecione o Tipo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

                if (!int.TryParse(txtTempo.Text, out int tempo) || tempo <= 0)
                { MessageBox.Show("Tempo médio inválido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

                var cultura = new Cultura
                {
                    Id = _idSelecionado,
                    Nome = txtNome.Text.Trim(),
                    Tipo = cboTipo.Text.Trim(),
                    TempoMedioColheitaDias = tempo,
                    Descricao = txtDescricao.Text.Trim()
                };

                if (_idSelecionado == 0) _repo.Inserir(cultura);
                else _repo.Editar(cultura);

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
            { MessageBox.Show("Selecione uma cultura.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            if (MessageBox.Show("Excluir esta cultura?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try { _repo.Deletar(_idSelecionado); LimparCampos(); CarregarLista(); }
                catch (Exception ex) { MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void btnNovo_Click(object sender, EventArgs e) => LimparCampos();

        private void LimparCampos()
        {
            _idSelecionado = 0;
            txtNome.Text = txtTempo.Text = txtDescricao.Text = "";
            cboTipo.SelectedIndex = -1;
            listBoxCulturas.ClearSelected();
        }
    }
}
