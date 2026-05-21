namespace AgroSistema.Forms
{
    partial class FormColheita
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblFazenda = new System.Windows.Forms.Label(); this.lblCultura = new System.Windows.Forms.Label();
            this.lblPlantio = new System.Windows.Forms.Label(); this.lblColheita = new System.Windows.Forms.Label();
            this.lblToneladas = new System.Windows.Forms.Label(); this.lblObs = new System.Windows.Forms.Label();
            this.lblLista = new System.Windows.Forms.Label();
            this.cboFazenda = new System.Windows.Forms.ComboBox(); this.cboCultura = new System.Windows.Forms.ComboBox();
            this.dtpPlantio = new System.Windows.Forms.DateTimePicker(); this.dtpColheita = new System.Windows.Forms.DateTimePicker();
            this.chkColhido = new System.Windows.Forms.CheckBox();
            this.txtToneladas = new System.Windows.Forms.TextBox(); this.txtObservacoes = new System.Windows.Forms.TextBox();
            this.btnSalvar = new System.Windows.Forms.Button(); this.btnExcluir = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button(); this.listBoxColheitas = new System.Windows.Forms.ListBox();
            this.SuspendLayout();

            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(34, 85, 34);
            this.lblTitulo.Location = new System.Drawing.Point(12, 9); this.lblTitulo.Size = new System.Drawing.Size(370, 30);
            this.lblTitulo.Text = "🌱 Registro de Colheitas";

            this.lblFazenda.Location = new System.Drawing.Point(12, 55); this.lblFazenda.Text = "Fazenda:"; this.lblFazenda.Size = new System.Drawing.Size(80, 20);
            this.lblCultura.Location = new System.Drawing.Point(12, 85); this.lblCultura.Text = "Cultura:"; this.lblCultura.Size = new System.Drawing.Size(80, 20);
            this.lblPlantio.Location = new System.Drawing.Point(12, 115); this.lblPlantio.Text = "Data Plantio:"; this.lblPlantio.Size = new System.Drawing.Size(85, 20);
            this.lblColheita.Location = new System.Drawing.Point(12, 145); this.lblColheita.Text = "Data Colheita:"; this.lblColheita.Size = new System.Drawing.Size(90, 20);
            this.lblToneladas.Location = new System.Drawing.Point(12, 175); this.lblToneladas.Text = "Toneladas:"; this.lblToneladas.Size = new System.Drawing.Size(85, 20);
            this.lblObs.Location = new System.Drawing.Point(12, 205); this.lblObs.Text = "Observações:"; this.lblObs.Size = new System.Drawing.Size(85, 20);

            this.cboFazenda.Location = new System.Drawing.Point(100, 52); this.cboFazenda.Size = new System.Drawing.Size(280, 23);
            this.cboFazenda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCultura.Location = new System.Drawing.Point(100, 82); this.cboCultura.Size = new System.Drawing.Size(200, 23);
            this.cboCultura.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.dtpPlantio.Location = new System.Drawing.Point(100, 112); this.dtpPlantio.Size = new System.Drawing.Size(150, 23);
            this.dtpPlantio.Format = System.Windows.Forms.DateTimePickerFormat.Short;

            this.chkColhido.Location = new System.Drawing.Point(100, 145); this.chkColhido.Size = new System.Drawing.Size(110, 20);
            this.chkColhido.Text = "Já foi colhida?";
            this.chkColhido.CheckedChanged += new System.EventHandler(this.chkColhido_CheckedChanged);

            this.dtpColheita.Location = new System.Drawing.Point(220, 142); this.dtpColheita.Size = new System.Drawing.Size(150, 23);
            this.dtpColheita.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpColheita.Enabled = false;

            this.txtToneladas.Location = new System.Drawing.Point(100, 172); this.txtToneladas.Size = new System.Drawing.Size(120, 23);
            this.txtToneladas.Enabled = false;

            this.txtObservacoes.Location = new System.Drawing.Point(100, 202); this.txtObservacoes.Size = new System.Drawing.Size(280, 23);

            this.btnNovo.Location = new System.Drawing.Point(12, 240); this.btnNovo.Size = new System.Drawing.Size(90, 32);
            this.btnNovo.Text = "Novo"; this.btnNovo.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.btnNovo.ForeColor = System.Drawing.Color.White; this.btnNovo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);

            this.btnSalvar.Location = new System.Drawing.Point(110, 240); this.btnSalvar.Size = new System.Drawing.Size(90, 32);
            this.btnSalvar.Text = "Salvar"; this.btnSalvar.BackColor = System.Drawing.Color.FromArgb(34, 139, 34);
            this.btnSalvar.ForeColor = System.Drawing.Color.White; this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);

            this.btnExcluir.Location = new System.Drawing.Point(208, 240); this.btnExcluir.Size = new System.Drawing.Size(90, 32);
            this.btnExcluir.Text = "Excluir"; this.btnExcluir.BackColor = System.Drawing.Color.FromArgb(220, 53, 69);
            this.btnExcluir.ForeColor = System.Drawing.Color.White; this.btnExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);

            this.lblLista.Location = new System.Drawing.Point(12, 288); this.lblLista.Size = new System.Drawing.Size(200, 20);
            this.lblLista.Text = "Colheitas Registradas:"; this.lblLista.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);

            this.listBoxColheitas.Location = new System.Drawing.Point(12, 310); this.listBoxColheitas.Size = new System.Drawing.Size(460, 140);
            this.listBoxColheitas.SelectedIndexChanged += new System.EventHandler(this.listBoxColheitas_SelectedIndexChanged);

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F); this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 470);
            this.Controls.Add(this.lblTitulo); this.Controls.Add(this.lblFazenda); this.Controls.Add(this.lblCultura);
            this.Controls.Add(this.lblPlantio); this.Controls.Add(this.lblColheita); this.Controls.Add(this.lblToneladas);
            this.Controls.Add(this.lblObs); this.Controls.Add(this.cboFazenda); this.Controls.Add(this.cboCultura);
            this.Controls.Add(this.dtpPlantio); this.Controls.Add(this.chkColhido); this.Controls.Add(this.dtpColheita);
            this.Controls.Add(this.txtToneladas); this.Controls.Add(this.txtObservacoes);
            this.Controls.Add(this.btnNovo); this.Controls.Add(this.btnSalvar); this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.lblLista); this.Controls.Add(this.listBoxColheitas);
            this.Text = "Colheitas"; this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FormColheita_Load);
            this.ResumeLayout(false); this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitulo, lblFazenda, lblCultura, lblPlantio, lblColheita, lblToneladas, lblObs, lblLista;
        private System.Windows.Forms.ComboBox cboFazenda, cboCultura;
        private System.Windows.Forms.DateTimePicker dtpPlantio, dtpColheita;
        private System.Windows.Forms.CheckBox chkColhido;
        private System.Windows.Forms.TextBox txtToneladas, txtObservacoes;
        private System.Windows.Forms.Button btnSalvar, btnExcluir, btnNovo;
        private System.Windows.Forms.ListBox listBoxColheitas;
    }
}
