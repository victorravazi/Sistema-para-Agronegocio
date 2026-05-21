namespace AgroSistema.Forms
{
    partial class FormFuncionario
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblNome = new System.Windows.Forms.Label(); this.lblCPF = new System.Windows.Forms.Label();
            this.lblCargo = new System.Windows.Forms.Label(); this.lblSalario = new System.Windows.Forms.Label();
            this.lblFazenda = new System.Windows.Forms.Label(); this.lblLista = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox(); this.txtCPF = new System.Windows.Forms.TextBox();
            this.txtSalario = new System.Windows.Forms.TextBox();
            this.cboCargo = new System.Windows.Forms.ComboBox(); this.cboFazenda = new System.Windows.Forms.ComboBox();
            this.btnSalvar = new System.Windows.Forms.Button(); this.btnExcluir = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button(); this.listBoxFuncionarios = new System.Windows.Forms.ListBox();
            this.SuspendLayout();

            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(34, 85, 34);
            this.lblTitulo.Location = new System.Drawing.Point(12, 9); this.lblTitulo.Size = new System.Drawing.Size(350, 30);
            this.lblTitulo.Text = "👷 Cadastro de Funcionários";

            int[] tops = { 55, 85, 115, 145, 175 };
            string[] lblTexts = { "Nome:", "CPF:", "Cargo:", "Salário:", "Fazenda:" };
            System.Windows.Forms.Label[] labels = { lblNome, lblCPF, lblCargo, lblSalario, lblFazenda };
            for (int i = 0; i < labels.Length; i++)
            { labels[i].Location = new System.Drawing.Point(12, tops[i]); labels[i].Size = new System.Drawing.Size(80, 20); labels[i].Text = lblTexts[i]; }

            this.txtNome.Location = new System.Drawing.Point(100, 52); this.txtNome.Size = new System.Drawing.Size(280, 23);
            this.txtCPF.Location = new System.Drawing.Point(100, 82); this.txtCPF.Size = new System.Drawing.Size(160, 23);
            this.txtSalario.Location = new System.Drawing.Point(100, 142); this.txtSalario.Size = new System.Drawing.Size(120, 23);

            this.cboCargo.Location = new System.Drawing.Point(100, 112); this.cboCargo.Size = new System.Drawing.Size(200, 23);

            this.cboFazenda.Location = new System.Drawing.Point(100, 172); this.cboFazenda.Size = new System.Drawing.Size(280, 23);
            this.cboFazenda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

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
            this.lblLista.Text = "Funcionários Cadastrados:"; this.lblLista.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);

            this.listBoxFuncionarios.Location = new System.Drawing.Point(12, 280); this.listBoxFuncionarios.Size = new System.Drawing.Size(460, 160);
            this.listBoxFuncionarios.SelectedIndexChanged += new System.EventHandler(this.listBoxFuncionarios_SelectedIndexChanged);

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F); this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 460);
            this.Controls.Add(this.lblTitulo);
            foreach (var l in labels) this.Controls.Add(l);
            this.Controls.Add(this.txtNome); this.Controls.Add(this.txtCPF); this.Controls.Add(this.txtSalario);
            this.Controls.Add(this.cboCargo); this.Controls.Add(this.cboFazenda);
            this.Controls.Add(this.btnNovo); this.Controls.Add(this.btnSalvar); this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.lblLista); this.Controls.Add(this.listBoxFuncionarios);
            this.Text = "Funcionários"; this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FormFuncionario_Load);
            this.ResumeLayout(false); this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitulo, lblNome, lblCPF, lblCargo, lblSalario, lblFazenda, lblLista;
        private System.Windows.Forms.TextBox txtNome, txtCPF, txtSalario;
        private System.Windows.Forms.ComboBox cboCargo, cboFazenda;
        private System.Windows.Forms.Button btnSalvar, btnExcluir, btnNovo;
        private System.Windows.Forms.ListBox listBoxFuncionarios;
    }
}
