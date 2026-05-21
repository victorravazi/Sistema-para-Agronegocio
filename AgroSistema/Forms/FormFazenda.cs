using System;
using System.Windows.Forms;
using AgroSistema.Models;
using AgroSistema.Repositories;

namespace AgroSistema.Forms
{
    public partial class FormFazenda : Form
    {
        private readonly RepositorioFazenda _repo = new RepositorioFazenda();
        private readonly RepositorioProdutor _repoProd = new RepositorioProdutor();
        private int _idSelecionado = 0;

        public FormFazenda()
        {
            InitializeComponent();
        }

        private void FormFazenda_Load(object sender, EventArgs e)
        {
            CarregarComboEstados();
            CarregarComboProdutores();
            CarregarLista();
        }

        private void CarregarComboEstados()
        {
            
            cboEstado.Items.Clear();
            string[] estados = { "AC","AL","AM","AP","BA","CE","DF","ES","GO","MA",
                                  "MG","MS","MT","PA","PB","PE","PI","PR","RJ","RN",
                                  "RO","RR","RS","SC","SE","SP","TO" };
            cboEstado.Items.AddRange(estados);
        }

        private void CarregarComboProdutores()
        {
            try
            {
                var produtores = _repoProd.ListarTodos();
                cboProdutores.DataSource = produtores;
                cboProdutores.DisplayMember = "Nome";
                cboProdutores.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar produtores: " + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarLista()
        {
            try
            {
                listBoxFazendas.DataSource = null;
                listBoxFazendas.DataSource = _repo.ListarTodos();
                listBoxFazendas.DisplayMember = "Nome";
                listBoxFazendas.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar fazendas: " + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listBoxFazendas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxFazendas.SelectedItem is Fazenda f)
            {
                _idSelecionado = f.Id;
                txtNome.Text = f.Nome;
                txtCidade.Text = f.Cidade;
                cboEstado.SelectedItem = f.Estado;
                txtArea.Text = f.AreaHectares.ToString();

                if (cboProdutores.Items.Count > 0)
                {
                    foreach (Produtor p in cboProdutores.Items)
                    {
                        if (p.Id == f.ProdutorId)
                        {
                            cboProdutores.SelectedItem = p;
                            break;
                        }
                    }
                }
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNome.Text))
                {
                    MessageBox.Show("Preencha o Nome da Fazenda.", "Atenção",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtCidade.Text))
                {
                    MessageBox.Show("Preencha a Cidade.", "Atenção",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (cboEstado.SelectedItem == null)
                {
                    MessageBox.Show("Selecione o Estado.", "Atenção",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!decimal.TryParse(txtArea.Text, out decimal area) || area <= 0)
                {
                    MessageBox.Show("Área em hectares inválida.", "Atenção",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (cboProdutores.SelectedItem == null)
                {
                    MessageBox.Show("Selecione o Produtor.", "Atenção",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var fazenda = new Fazenda
                {
                    Id = _idSelecionado,
                    Nome = txtNome.Text.Trim(),
                    Cidade = txtCidade.Text.Trim(),
                    Estado = cboEstado.SelectedItem.ToString(),
                    AreaHectares = area,
                    ProdutorId = ((Produtor)cboProdutores.SelectedItem).Id
                };

                if (_idSelecionado == 0)
                    _repo.Inserir(fazenda);
                else
                    _repo.Editar(fazenda);

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
                MessageBox.Show("Selecione uma fazenda para excluir.", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var repoFunc = new RepositorioFuncionario();
            var funcionarios = repoFunc.ListarPorFazenda(_idSelecionado);
            if (funcionarios.Count > 0)
            {
                MessageBox.Show("Esta fazenda possui funcionários cadastrados. Exclua os funcionários primeiro.",
                    "Não é possível excluir", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var repoColheita = new RepositorioColheita();
            var colheitas = repoColheita.ListarPorFazenda(_idSelecionado);
            if (colheitas.Count > 0)
            {
                MessageBox.Show("Esta fazenda possui colheitas registradas. Exclua as colheitas primeiro.",
                    "Não é possível excluir", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show("Deseja excluir esta fazenda?", "Confirmar",
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

        private void btnNovo_Click(object sender, EventArgs e) => LimparCampos();

        private void LimparCampos()
        {
            _idSelecionado = 0;
            txtNome.Text = "";
            txtCidade.Text = "";
            txtArea.Text = "";
            cboEstado.SelectedIndex = -1;
            if (cboProdutores.Items.Count > 0)
                cboProdutores.SelectedIndex = 0;
            listBoxFazendas.ClearSelected();
        }
    }
}
