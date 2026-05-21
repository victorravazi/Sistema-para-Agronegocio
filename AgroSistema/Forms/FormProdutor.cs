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

        
        private void FormProdutor_Load(object sender, EventArgs e)
        {
            CarregarLista();
        }

        
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

        
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validacoes (Nome, CPF, Email)
                if (string.IsNullOrWhiteSpace(txtNome.Text))
                {
                    MessageBox.Show("Preencha o Nome.", "Atenção",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNome.Focus();
                    return;
                }
                if (!CPFValido(txtCPF.Text))
                {
                    MessageBox.Show("CPF inválido.", "Atenção",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCPF.Focus();
                    return;
                }
                if (!EmailValido(txtEmail.Text))
                {
                    MessageBox.Show("Preencha um e-mail válido.", "Atenção",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
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

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (_idSelecionado == 0)
            {
                MessageBox.Show("Selecione um produtor para excluir.", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var repoFaz = new RepositorioFazenda();
            var fazendas = repoFaz.ListarPorProdutor(_idSelecionado);
            if (fazendas.Count > 0)
            {
                MessageBox.Show("Este produtor possui fazendas cadastradas. Exclua as fazendas primeiro.",
                    "Não é possível excluir", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private bool EmailValido(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false; 
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private bool CPFValido(string cpf)
        {
            cpf = cpf.Replace(".", "").Replace("-", "").Replace(" ", "");

            if (cpf.Length != 11) return false;

            if (new string(cpf[0], 11) == cpf) return false;

            int soma = 0;
            for (int i = 0; i < 9; i++)
                soma += int.Parse(cpf[i].ToString()) * (10 - i);
            int resto = (soma * 10) % 11;
            if (resto == 10 || resto == 11) resto = 0;
            if (resto != int.Parse(cpf[9].ToString())) return false;

            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(cpf[i].ToString()) * (11 - i);
            resto = (soma * 10) % 11;
            if (resto == 10 || resto == 11) resto = 0;
            if (resto != int.Parse(cpf[10].ToString())) return false;

            return true;
        }
    }
}
