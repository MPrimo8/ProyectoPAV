namespace pav.GUILayer.Articulos
{
    partial class frmConsultaArt
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblFechaAlta = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvArticulo = new System.Windows.Forms.DataGridView();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.btnDetalle = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.txtFechaAlta = new System.Windows.Forms.MaskedTextBox();
            this.txtFechaHasta = new System.Windows.Forms.MaskedTextBox();
            this.cboMarcas = new System.Windows.Forms.ComboBox();
            this.cboTipoArt = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFechaAlta
            // 
            this.lblFechaAlta.AutoSize = true;
            this.lblFechaAlta.Location = new System.Drawing.Point(39, 31);
            this.lblFechaAlta.Name = "lblFechaAlta";
            this.lblFechaAlta.Size = new System.Drawing.Size(58, 13);
            this.lblFechaAlta.TabIndex = 0;
            this.lblFechaAlta.Text = "Fecha Alta";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Marca";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(342, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Fecha Hasta";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(342, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Tipo Articulo";
            // 
            // dgvArticulo
            // 
            this.dgvArticulo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArticulo.Location = new System.Drawing.Point(42, 171);
            this.dgvArticulo.Name = "dgvArticulo";
            this.dgvArticulo.Size = new System.Drawing.Size(526, 150);
            this.dgvArticulo.TabIndex = 11;
            // 
            // btnConsultar
            // 
            this.btnConsultar.Location = new System.Drawing.Point(493, 142);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(75, 23);
            this.btnConsultar.TabIndex = 12;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.BtnConsultar_Click);
            // 
            // btnDetalle
            // 
            this.btnDetalle.Location = new System.Drawing.Point(196, 342);
            this.btnDetalle.Name = "btnDetalle";
            this.btnDetalle.Size = new System.Drawing.Size(75, 23);
            this.btnDetalle.TabIndex = 13;
            this.btnDetalle.Text = "Detalle";
            this.btnDetalle.UseVisualStyleBackColor = true;
            this.btnDetalle.Click += new System.EventHandler(this.BtnDetalle_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(493, 342);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 14;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // txtFechaAlta
            // 
            this.txtFechaAlta.Location = new System.Drawing.Point(171, 31);
            this.txtFechaAlta.Mask = "00/00/0000";
            this.txtFechaAlta.Name = "txtFechaAlta";
            this.txtFechaAlta.Size = new System.Drawing.Size(121, 20);
            this.txtFechaAlta.TabIndex = 15;
            this.txtFechaAlta.ValidatingType = typeof(System.DateTime);
            // 
            // txtFechaHasta
            // 
            this.txtFechaHasta.Location = new System.Drawing.Point(430, 31);
            this.txtFechaHasta.Mask = "00/00/0000";
            this.txtFechaHasta.Name = "txtFechaHasta";
            this.txtFechaHasta.Size = new System.Drawing.Size(121, 20);
            this.txtFechaHasta.TabIndex = 16;
            this.txtFechaHasta.ValidatingType = typeof(System.DateTime);
            // 
            // cboMarcas
            // 
            this.cboMarcas.FormattingEnabled = true;
            this.cboMarcas.Location = new System.Drawing.Point(171, 74);
            this.cboMarcas.Name = "cboMarcas";
            this.cboMarcas.Size = new System.Drawing.Size(121, 21);
            this.cboMarcas.TabIndex = 17;
            // 
            // cboTipoArt
            // 
            this.cboTipoArt.FormattingEnabled = true;
            this.cboTipoArt.Items.AddRange(new object[] {
            "Suplemento"});
            this.cboTipoArt.Location = new System.Drawing.Point(430, 76);
            this.cboTipoArt.Name = "cboTipoArt";
            this.cboTipoArt.Size = new System.Drawing.Size(121, 21);
            this.cboTipoArt.TabIndex = 18;
            // 
            // frmConsultaArt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 376);
            this.Controls.Add(this.cboTipoArt);
            this.Controls.Add(this.cboMarcas);
            this.Controls.Add(this.txtFechaHasta);
            this.Controls.Add(this.txtFechaAlta);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnDetalle);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.dgvArticulo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblFechaAlta);
            this.Name = "frmConsultaArt";
            this.Text = "frmConsultaArt";
            this.Load += new System.EventHandler(this.FrmConsultaArt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFechaAlta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvArticulo;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.Button btnDetalle;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.MaskedTextBox txtFechaAlta;
        private System.Windows.Forms.MaskedTextBox txtFechaHasta;
        private System.Windows.Forms.ComboBox cboMarcas;
        private System.Windows.Forms.ComboBox cboTipoArt;
    }
}