namespace AgroSistema.Forms
{
    partial class FormPrincipal
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnProdutores = new System.Windows.Forms.Button();
            this.btnFazendas = new System.Windows.Forms.Button();
            this.btnFuncionarios = new System.Windows.Forms.Button();
            this.btnCulturas = new System.Windows.Forms.Button();
            this.btnColheitas = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.panelMenu.SuspendLayout();
            this.SuspendLayout();

            // panelHeader
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(34, 85, 34);
            this.panelHeader.Controls.Add(this.lblTitulo);
            this.panelHeader.Controls.Add(this.lblSubtitulo);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Size = new System.Drawing.Size(420, 100);

            // lblTitulo
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(20, 15);
            this.lblTitulo.Size = new System.Drawing.Size(380, 45);
            this.lblTitulo.Text = "🌾 AgroSistema";

            // lblSubtitulo
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(200, 255, 200);
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubtitulo.Location = new System.Drawing.Point(22, 58);
            this.lblSubtitulo.Size = new System.Drawing.Size(380, 25);
            this.lblSubtitulo.Text = "Sistema de Gestão do Agronegócio";

            // panelMenu
            this.panelMenu.Location = new System.Drawing.Point(20, 120);
            this.panelMenu.Size = new System.Drawing.Size(380, 350);
            this.panelMenu.Controls.Add(this.btnProdutores);
            this.panelMenu.Controls.Add(this.btnFazendas);
            this.panelMenu.Controls.Add(this.btnFuncionarios);
            this.panelMenu.Controls.Add(this.btnCulturas);
            this.panelMenu.Controls.Add(this.btnColheitas);
            this.panelMenu.Controls.Add(this.btnSair);

            // Configuração dos botões do menu
            System.Windows.Forms.Button[] btns = {
                btnProdutores, btnFazendas, btnFuncionarios, btnCulturas, btnColheitas, btnSair
            };
            string[] texts = {
                "👨‍🌾  Produtores", "🚜  Fazendas", "👷  Funcionários",
                "🌿  Culturas", "🌱  Colheitas", "🚪  Sair"
            };
            System.Drawing.Color[] colors = {
                System.Drawing.Color.FromArgb(40, 120, 40),
                System.Drawing.Color.FromArgb(50, 140, 50),
                System.Drawing.Color.FromArgb(60, 100, 160),
                System.Drawing.Color.FromArgb(120, 160, 40),
                System.Drawing.Color.FromArgb(200, 120, 30),
                System.Drawing.Color.FromArgb(160, 40, 40)
            };

            for (int i = 0; i < btns.Length; i++)
            {
                btns[i].Location = new System.Drawing.Point(0, i * 55);
                btns[i].Size = new System.Drawing.Size(380, 48);
                btns[i].Text = texts[i];
                btns[i].BackColor = colors[i];
                btns[i].ForeColor = System.Drawing.Color.White;
                btns[i].Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
                btns[i].FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                btns[i].FlatAppearance.BorderSize = 0;
                btns[i].TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                btns[i].Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
                btns[i].Cursor = System.Windows.Forms.Cursors.Hand;
            }

            this.btnProdutores.Click += new System.EventHandler(this.btnProdutores_Click);
            this.btnFazendas.Click += new System.EventHandler(this.btnFazendas_Click);
            this.btnFuncionarios.Click += new System.EventHandler(this.btnFuncionarios_Click);
            this.btnCulturas.Click += new System.EventHandler(this.btnCulturas_Click);
            this.btnColheitas.Click += new System.EventHandler(this.btnColheitas_Click);
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);

            // Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 490);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelMenu);
            this.Text = "AgroSistema";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = System.Drawing.Color.FromArgb(245, 250, 245);
            this.panelHeader.ResumeLayout(false);
            this.panelMenu.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelHeader, panelMenu;
        private System.Windows.Forms.Label lblTitulo, lblSubtitulo;
        private System.Windows.Forms.Button btnProdutores, btnFazendas, btnFuncionarios;
        private System.Windows.Forms.Button btnCulturas, btnColheitas, btnSair;
    }
}
