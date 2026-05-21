using System;
using System.Windows.Forms;
using AgroSistema.Models;
using AgroSistema.Repositories;

namespace AgroSistema.Forms
{
    public partial class FormProdutor : Form
    {
        private readonly RepositorioProdutor _repo = new RepositorioProdutor();
        private int _idSelecionado = 0;

        public FormProdutor()
        {
            InitializeComponent();
        }

        // ── Eventos de ciclo de vida ──────────────────────────────────────
        private void FormProdutor_Load(object sender, EventArgs e)
        {
            CarregarLista();
        }

        // ── Carregar lista ────────────────────────────────────────────────
        private void CarregarLista()
        {
            try
            {
                listBoxProdutores.DataSource = null;
                listBoxProdutores.DataSource = _repo.ListarTodos();
                listBoxProdutores.DisplayMember = "Nome";
                listBoxProdutores.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar produtores: " + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Seleção na lista ──────────────────────────────────────────────
        private void listBoxProdutores_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxProdutores.SelectedItem is Produtor p)
            {
                _idSelecionado = p.Id;
                txtNome.Text = p.Nome;
                txtCPF.Text = p.CPF;
                txtTelefone.Text = p.Telefone;
                txtEmail.Text = p.Email;
            }
        }

        // ── Botão Salvar ──────────────────────────────────────────────────
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validação
                if (string.IsNullOrWhiteSpace(txtNome.Text))
                {
                    MessageBox.Show("Preencha o Nome.", "Atenção",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNome.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtCPF.Text) || txtCPF.Text.Length < 11)
                {
                    MessageBox.Show("CPF inválido.", "Atenção",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCPF.Focus();
                    return;
                }

                var produtor = new Produtor
                {
                    Id = _idSelecionado,
                    Nome = txtNome.Text.Trim(),
                    CPF = txtCPF.Text.Trim(),
                    Telefone = txtTelefone.Text.Trim(),
                    Email = txtEmail.Text.Trim()
                };

                if (_idSelecionado == 0)
                    _repo.Inserir(produtor);
                else
                    _repo.Editar(produtor);

                MessageBox.Show("Salvo com sucesso!", "OK",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimparCampos();
                CarregarLista();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar: " + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Botão Excluir ─────────────────────────────────────────────────
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (_idSelecionado == 0)
            {
                MessageBox.Show("Selecione um produtor para excluir.", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show("Deseja excluir este produtor?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    _repo.Deletar(_idSelecionado);
                    LimparCampos();
                    CarregarLista();
                    MessageBox.Show("Excluído com sucesso!", "OK",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao excluir: " + ex.Message,
                        "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ── Botão Novo ────────────────────────────────────────────────────
        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void LimparCampos()
        {
            _idSelecionado = 0;
            txtNome.Text = "";
            txtCPF.Text = "";
            txtTelefone.Text = "";
            txtEmail.Text = "";
            listBoxProdutores.ClearSelected();
        }
    }
}
