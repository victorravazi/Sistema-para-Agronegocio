using System;
using System.Windows.Forms;

namespace AgroSistema.Forms
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void btnProdutores_Click(object sender, EventArgs e)
        {
            new FormProdutor().Show();
        }

        private void btnFazendas_Click(object sender, EventArgs e)
        {
            new FormFazenda().Show();
        }

        private void btnFuncionarios_Click(object sender, EventArgs e)
        {
            new FormFuncionario().Show();
        }

        private void btnCulturas_Click(object sender, EventArgs e)
        {
            new FormCultura().Show();
        }

        private void btnColheitas_Click(object sender, EventArgs e)
        {
            new FormColheita().Show();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja sair do sistema?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
