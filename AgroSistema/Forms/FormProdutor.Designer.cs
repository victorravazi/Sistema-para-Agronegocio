namespace AgroSistema.Forms
{
    partial class FormProdutor
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblNome = new System.Windows.Forms.Label();
            this.lblCPF = new System.Windows.Forms.Label();
            this.lblTelefone = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtCPF = new System.Windows.Forms.TextBox();
            this.txtTelefone = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.listBoxProdutores = new System.Windows.Forms.ListBox();
            this.lblLista = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // lblTitulo
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(34, 85, 34);
            this.lblTitulo.Location = new System.Drawing.Point(12, 9);
            this.lblTitulo.Size = new System.Drawing.Size(350, 30);
            this.lblTitulo.Text = "🌾 Cadastro de Produtores";

            // Labels
            this.lblNome.Location = new System.Drawing.Point(12, 55);
            this.lblNome.Size = new System.Drawing.Size(80, 20);
            this.lblNome.Text = "Nome:";

            this.lblCPF.Location = new System.Drawing.Point(12, 85);
            this.lblCPF.Size = new System.Drawing.Size(80, 20);
            this.lblCPF.Text = "CPF:";

            this.lblTelefone.Location = new System.Drawing.Point(12, 115);
            this.lblTelefone.Size = new System.Drawing.Size(80, 20);
            this.lblTelefone.Text = "Telefone:";

            this.lblEmail.Location = new System.Drawing.Point(12, 145);
            this.lblEmail.Size = new System.Drawing.Size(80, 20);
            this.lblEmail.Text = "E-mail:";

            // TextBoxes
            this.txtNome.Location = new System.Drawing.Point(100, 52);
            this.txtNome.Size = new System.Drawing.Size(280, 23);

            this.txtCPF.Location = new System.Drawing.Point(100, 82);
            this.txtCPF.Size = new System.Drawing.Size(160, 23);

            this.txtTelefone.Location = new System.Drawing.Point(100, 112);
            this.txtTelefone.Size = new System.Drawing.Size(160, 23);

            this.txtEmail.Location = new System.Drawing.Point(100, 142);
            this.txtEmail.Size = new System.Drawing.Size(280, 23);

            // Buttons
            this.btnNovo.Location = new System.Drawing.Point(12, 180);
            this.btnNovo.Size = new System.Drawing.Size(90, 32);
            this.btnNovo.Text = "Novo";
            this.btnNovo.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.btnNovo.ForeColor = System.Drawing.Color.White;
            this.btnNovo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);

            this.btnSalvar.Location = new System.Drawing.Point(110, 180);
            this.btnSalvar.Size = new System.Drawing.Size(90, 32);
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.BackColor = System.Drawing.Color.FromArgb(34, 139, 34);
            this.btnSalvar.ForeColor = System.Drawing.Color.White;
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);

            this.btnExcluir.Location = new System.Drawing.Point(208, 180);
            this.btnExcluir.Size = new System.Drawing.Size(90, 32);
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.BackColor = System.Drawing.Color.FromArgb(220, 53, 69);
            this.btnExcluir.ForeColor = System.Drawing.Color.White;
            this.btnExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);

            // ListBox
            this.lblLista.Location = new System.Drawing.Point(12, 228);
            this.lblLista.Size = new System.Drawing.Size(200, 20);
            this.lblLista.Text = "Produtores Cadastrados:";
            this.lblLista.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);

            this.listBoxProdutores.Location = new System.Drawing.Point(12, 250);
            this.listBoxProdutores.Size = new System.Drawing.Size(460, 180);
            this.listBoxProdutores.SelectedIndexChanged += new System.EventHandler(this.listBoxProdutores_SelectedIndexChanged);

            // Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 451);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.lblCPF);
            this.Controls.Add(this.lblTelefone);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.txtCPF);
            this.Controls.Add(this.txtTelefone);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.lblLista);
            this.Controls.Add(this.listBoxProdutores);
            this.Text = "Produtores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FormProdutor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label lblCPF;
        private System.Windows.Forms.Label lblTelefone;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblLista;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtCPF;
        private System.Windows.Forms.TextBox txtTelefone;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.ListBox listBoxProdutores;
    }
}
