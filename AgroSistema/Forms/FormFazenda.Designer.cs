namespace AgroSistema.Forms
{
    partial class FormFazenda
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
            this.lblCidade = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblArea = new System.Windows.Forms.Label();
            this.lblProdutor = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtCidade = new System.Windows.Forms.TextBox();
            this.txtArea = new System.Windows.Forms.TextBox();
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.cboProdutores = new System.Windows.Forms.ComboBox();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.listBoxFazendas = new System.Windows.Forms.ListBox();
            this.lblLista = new System.Windows.Forms.Label();
            this.SuspendLayout();

            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(34, 85, 34);
            this.lblTitulo.Location = new System.Drawing.Point(12, 9);
            this.lblTitulo.Size = new System.Drawing.Size(350, 30);
            this.lblTitulo.Text = "🚜 Cadastro de Fazendas";

            this.lblNome.Location = new System.Drawing.Point(12, 55); this.lblNome.Text = "Nome:"; this.lblNome.Size = new System.Drawing.Size(80, 20);
            this.lblCidade.Location = new System.Drawing.Point(12, 85); this.lblCidade.Text = "Cidade:"; this.lblCidade.Size = new System.Drawing.Size(80, 20);
            this.lblEstado.Location = new System.Drawing.Point(12, 115); this.lblEstado.Text = "Estado:"; this.lblEstado.Size = new System.Drawing.Size(80, 20);
            this.lblArea.Location = new System.Drawing.Point(12, 145); this.lblArea.Text = "Área (ha):"; this.lblArea.Size = new System.Drawing.Size(80, 20);
            this.lblProdutor.Location = new System.Drawing.Point(12, 175); this.lblProdutor.Text = "Produtor:"; this.lblProdutor.Size = new System.Drawing.Size(80, 20);

            this.txtNome.Location = new System.Drawing.Point(100, 52); this.txtNome.Size = new System.Drawing.Size(280, 23);
            this.txtCidade.Location = new System.Drawing.Point(100, 82); this.txtCidade.Size = new System.Drawing.Size(200, 23);
            this.txtArea.Location = new System.Drawing.Point(100, 142); this.txtArea.Size = new System.Drawing.Size(120, 23);

            this.cboEstado.Location = new System.Drawing.Point(100, 112);
            this.cboEstado.Size = new System.Drawing.Size(80, 23);
            this.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.cboProdutores.Location = new System.Drawing.Point(100, 172);
            this.cboProdutores.Size = new System.Drawing.Size(280, 23);
            this.cboProdutores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.btnNovo.Location = new System.Drawing.Point(12, 210); this.btnNovo.Size = new System.Drawing.Size(90, 32);
            this.btnNovo.Text = "Novo"; this.btnNovo.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.btnNovo.ForeColor = System.Drawing.Color.White; this.btnNovo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);

            this.btnSalvar.Location = new System.Drawing.Point(110, 210); this.btnSalvar.Size = new System.Drawing.Size(90, 32);
            this.btnSalvar.Text = "Salvar"; this.btnSalvar.BackColor = System.Drawing.Color.FromArgb(34, 139, 34);
            this.btnSalvar.ForeColor = System.Drawing.Color.White; this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);

            this.btnExcluir.Location = new System.Drawing.Point(208, 210); this.btnExcluir.Size = new System.Drawing.Size(90, 32);
            this.btnExcluir.Text = "Excluir"; this.btnExcluir.BackColor = System.Drawing.Color.FromArgb(220, 53, 69);
            this.btnExcluir.ForeColor = System.Drawing.Color.White; this.btnExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);

            this.lblLista.Location = new System.Drawing.Point(12, 258); this.lblLista.Size = new System.Drawing.Size(200, 20);
            this.lblLista.Text = "Fazendas Cadastradas:"; this.lblLista.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);

            this.listBoxFazendas.Location = new System.Drawing.Point(12, 280); this.listBoxFazendas.Size = new System.Drawing.Size(460, 160);
            this.listBoxFazendas.SelectedIndexChanged += new System.EventHandler(this.listBoxFazendas_SelectedIndexChanged);

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 460);
            this.Controls.Add(this.lblTitulo); this.Controls.Add(this.lblNome); this.Controls.Add(this.lblCidade);
            this.Controls.Add(this.lblEstado); this.Controls.Add(this.lblArea); this.Controls.Add(this.lblProdutor);
            this.Controls.Add(this.txtNome); this.Controls.Add(this.txtCidade); this.Controls.Add(this.txtArea);
            this.Controls.Add(this.cboEstado); this.Controls.Add(this.cboProdutores);
            this.Controls.Add(this.btnNovo); this.Controls.Add(this.btnSalvar); this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.lblLista); this.Controls.Add(this.listBoxFazendas);
            this.Text = "Fazendas"; this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FormFazenda_Load);
            this.ResumeLayout(false); this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitulo, lblNome, lblCidade, lblEstado, lblArea, lblProdutor, lblLista;
        private System.Windows.Forms.TextBox txtNome, txtCidade, txtArea;
        private System.Windows.Forms.ComboBox cboEstado, cboProdutores;
        private System.Windows.Forms.Button btnSalvar, btnExcluir, btnNovo;
        private System.Windows.Forms.ListBox listBoxFazendas;
    }
}
