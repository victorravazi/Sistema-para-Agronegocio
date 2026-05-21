using System;
using System.Windows.Forms;
using AgroSistema.Models;
using AgroSistema.Repositories;

namespace AgroSistema.Forms
{
    public partial class FormFuncionario : Form
    {
        private readonly RepositorioFuncionario _repo = new RepositorioFuncionario();
        private readonly RepositorioFazenda _repoFaz = new RepositorioFazenda();
        private int _idSelecionado = 0;

        public FormFuncionario()
        {
            InitializeComponent();
        }

        private void FormFuncionario_Load(object sender, EventArgs e)
        {
            CarregarComboCargos();
            CarregarComboFazendas();
            CarregarLista();
        }

        private void CarregarComboCargos()
        {
            cboCargo.Items.Clear();
            cboCargo.Items.AddRange(new string[]
            {
                "Gerente", "Supervisor", "Operador de Máquinas", "Tratorista",
                "Agrônomo", "Veterinário", "Técnico Agrícola", "Peão", "Administrador"
            });
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
                MessageBox.Show("Erro ao carregar fazendas: " + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarLista()
        {
            try
            {
                listBoxFuncionarios.DataSource = null;
                listBoxFuncionarios.DataSource = _repo.ListarTodos();
                listBoxFuncionarios.DisplayMember = "Nome";
                listBoxFuncionarios.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar funcionários: " + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listBoxFuncionarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxFuncionarios.SelectedItem is Funcionario f)
            {
                _idSelecionado = f.Id;
                txtNome.Text = f.Nome;
                txtCPF.Text = f.CPF;
                cboCargo.Text = f.Cargo;
                txtSalario.Text = f.Salario.ToString("F2");

                foreach (Fazenda faz in cboFazenda.Items)
                {
                    if (faz.Id == f.FazendaId)
                    {
                        cboFazenda.SelectedItem = faz;
                        break;
                    }
                }
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNome.Text))
                { MessageBox.Show("Preencha o Nome.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

                if (string.IsNullOrWhiteSpace(txtCPF.Text) || txtCPF.Text.Length < 11)
                { MessageBox.Show("CPF inválido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

                if (cboCargo.SelectedItem == null && string.IsNullOrWhiteSpace(cboCargo.Text))
                { MessageBox.Show("Selecione ou informe o Cargo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

                if (!decimal.TryParse(txtSalario.Text, out decimal salario) || salario <= 0)
                { MessageBox.Show("Salário inválido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

                if (cboFazenda.SelectedItem == null)
                { MessageBox.Show("Selecione a Fazenda.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

                var funcionario = new Funcionario
                {
                    Id = _idSelecionado,
                    Nome = txtNome.Text.Trim(),
                    CPF = txtCPF.Text.Trim(),
                    Cargo = cboCargo.Text.Trim(),
                    Salario = salario,
                    FazendaId = ((Fazenda)cboFazenda.SelectedItem).Id
                };

                if (_idSelecionado == 0)
                    _repo.Inserir(funcionario);
                else
                    _repo.Editar(funcionario);

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
            { MessageBox.Show("Selecione um funcionário.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            if (MessageBox.Show("Excluir este funcionário?", "Confirmar",
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

        private void LimparCampos()
        {
            _idSelecionado = 0;
            txtNome.Text = txtCPF.Text = txtSalario.Text = "";
            cboCargo.SelectedIndex = -1;
            if (cboFazenda.Items.Count > 0) cboFazenda.SelectedIndex = 0;
            listBoxFuncionarios.ClearSelected();
        }
    }
}
