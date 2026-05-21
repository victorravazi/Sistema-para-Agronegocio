namespace AgroSistema.Forms
{
    partial class FormCultura
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblNome = new System.Windows.Forms.Label(); this.lblTipo = new System.Windows.Forms.Label();
            this.lblTempo = new System.Windows.Forms.Label(); this.lblDescricao = new System.Windows.Forms.Label();
            this.lblLista = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox(); this.txtTempo = new System.Windows.Forms.TextBox();
            this.txtDescricao = new System.Windows.Forms.TextBox(); this.cboTipo = new System.Windows.Forms.ComboBox();
            this.btnSalvar = new System.Windows.Forms.Button(); this.btnExcluir = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button(); this.listBoxCulturas = new System.Windows.Forms.ListBox();
            this.SuspendLayout();

            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(34, 85, 34);
            this.lblTitulo.Location = new System.Drawing.Point(12, 9); this.lblTitulo.Size = new System.Drawing.Size(350, 30);
            this.lblTitulo.Text = "🌿 Cadastro de Culturas";

            this.lblNome.Location = new System.Drawing.Point(12, 55); this.lblNome.Text = "Nome:"; this.lblNome.Size = new System.Drawing.Size(100, 20);
            this.lblTipo.Location = new System.Drawing.Point(12, 85); this.lblTipo.Text = "Tipo:"; this.lblTipo.Size = new System.Drawing.Size(100, 20);
            this.lblTempo.Location = new System.Drawing.Point(12, 115); this.lblTempo.Text = "Tempo (dias):"; this.lblTempo.Size = new System.Drawing.Size(100, 20);
            this.lblDescricao.Location = new System.Drawing.Point(12, 145); this.lblDescricao.Text = "Descrição:"; this.lblDescricao.Size = new System.Drawing.Size(100, 20);

            this.txtNome.Location = new System.Drawing.Point(115, 52); this.txtNome.Size = new System.Drawing.Size(265, 23);
            this.cboTipo.Location = new System.Drawing.Point(115, 82); this.cboTipo.Size = new System.Drawing.Size(180, 23);
            this.txtTempo.Location = new System.Drawing.Point(115, 112); this.txtTempo.Size = new System.Drawing.Size(80, 23);
            this.txtDescricao.Location = new System.Drawing.Point(115, 142); this.txtDescricao.Size = new System.Drawing.Size(265, 23);

            this.btnNovo.Location = new System.Drawing.Point(12, 180); this.btnNovo.Size = new System.Drawing.Size(90, 32);
            this.btnNovo.Text = "Novo"; this.btnNovo.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.btnNovo.ForeColor = System.Drawing.Color.White; this.btnNovo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);

            this.btnSalvar.Location = new System.Drawing.Point(110, 180); this.btnSalvar.Size = new System.Drawing.Size(90, 32);
            this.btnSalvar.Text = "Salvar"; this.btnSalvar.BackColor = System.Drawing.Color.FromArgb(34, 139, 34);
            this.btnSalvar.ForeColor = System.Drawing.Color.White; this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);

            this.btnExcluir.Location = new System.Drawing.Point(208, 180); this.btnExcluir.Size = new System.Drawing.Size(90, 32);
            this.btnExcluir.Text = "Excluir"; this.btnExcluir.BackColor = System.Drawing.Color.FromArgb(220, 53, 69);
            this.btnExcluir.ForeColor = System.Drawing.Color.White; this.btnExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);

            this.lblLista.Location = new System.Drawing.Point(12, 228); this.lblLista.Size = new System.Drawing.Size(200, 20);
            this.lblLista.Text = "Culturas Cadastradas:"; this.lblLista.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);

            this.listBoxCulturas.Location = new System.Drawing.Point(12, 250); this.listBoxCulturas.Size = new System.Drawing.Size(460, 160);
            this.listBoxCulturas.SelectedIndexChanged += new System.EventHandler(this.listBoxCulturas_SelectedIndexChanged);

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F); this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 430);
            this.Controls.Add(this.lblTitulo); this.Controls.Add(this.lblNome); this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.lblTempo); this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.txtNome); this.Controls.Add(this.cboTipo); this.Controls.Add(this.txtTempo);
            this.Controls.Add(this.txtDescricao); this.Controls.Add(this.btnNovo); this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnExcluir); this.Controls.Add(this.lblLista); this.Controls.Add(this.listBoxCulturas);
            this.Text = "Culturas"; this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FormCultura_Load);
            this.ResumeLayout(false); this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitulo, lblNome, lblTipo, lblTempo, lblDescricao, lblLista;
        private System.Windows.Forms.TextBox txtNome, txtTempo, txtDescricao;
        private System.Windows.Forms.ComboBox cboTipo;
        private System.Windows.Forms.Button btnSalvar, btnExcluir, btnNovo;
        private System.Windows.Forms.ListBox listBoxCulturas;
    }
}
