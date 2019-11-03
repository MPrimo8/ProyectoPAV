namespace pav.GUILayer.Transacciones
{
    partial class frmTransFactura
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.txtNroFact = new System.Windows.Forms.TextBox();
            this.cboTipoFact = new System.Windows.Forms.ComboBox();
            this.lblNroFact = new System.Windows.Forms.Label();
            this.lblVendedor = new System.Windows.Forms.Label();
            this.cboIva = new System.Windows.Forms.ComboBox();
            this.cboCliente = new System.Windows.Forms.ComboBox();
            this.lblCondIVA = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblTipoFactura = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cboArticulo = new System.Windows.Forms.ComboBox();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.txtDescuento = new System.Windows.Forms.TextBox();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.NroItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodArt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripocion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Importe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSubTotal = new System.Windows.Forms.TextBox();
            this.txtImporte = new System.Windows.Forms.TextBox();
            this.txtImporteTotal = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dtpFecha);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.txtNroFact);
            this.panel1.Controls.Add(this.cboTipoFact);
            this.panel1.Controls.Add(this.lblNroFact);
            this.panel1.Controls.Add(this.lblVendedor);
            this.panel1.Controls.Add(this.cboIva);
            this.panel1.Controls.Add(this.cboCliente);
            this.panel1.Controls.Add(this.lblCondIVA);
            this.panel1.Controls.Add(this.lblCliente);
            this.panel1.Controls.Add(this.lblFecha);
            this.panel1.Controls.Add(this.lblTipoFactura);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(683, 176);
            this.panel1.TabIndex = 0;
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(120, 62);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(125, 20);
            this.dtpFecha.TabIndex = 23;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(432, 62);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(121, 20);
            this.textBox2.TabIndex = 22;
            // 
            // txtNroFact
            // 
            this.txtNroFact.Location = new System.Drawing.Point(432, 13);
            this.txtNroFact.Name = "txtNroFact";
            this.txtNroFact.Size = new System.Drawing.Size(121, 20);
            this.txtNroFact.TabIndex = 21;
            // 
            // cboTipoFact
            // 
            this.cboTipoFact.FormattingEnabled = true;
            this.cboTipoFact.Items.AddRange(new object[] {
            "A",
            "B",
            "C"});
            this.cboTipoFact.Location = new System.Drawing.Point(120, 12);
            this.cboTipoFact.Name = "cboTipoFact";
            this.cboTipoFact.Size = new System.Drawing.Size(125, 21);
            this.cboTipoFact.TabIndex = 20;
            // 
            // lblNroFact
            // 
            this.lblNroFact.AutoSize = true;
            this.lblNroFact.Location = new System.Drawing.Point(350, 20);
            this.lblNroFact.Name = "lblNroFact";
            this.lblNroFact.Size = new System.Drawing.Size(63, 13);
            this.lblNroFact.TabIndex = 18;
            this.lblNroFact.Text = "Nro Factura";
            // 
            // lblVendedor
            // 
            this.lblVendedor.AutoSize = true;
            this.lblVendedor.Location = new System.Drawing.Point(360, 66);
            this.lblVendedor.Name = "lblVendedor";
            this.lblVendedor.Size = new System.Drawing.Size(53, 13);
            this.lblVendedor.TabIndex = 17;
            this.lblVendedor.Text = "Vendedor";
            // 
            // cboIva
            // 
            this.cboIva.FormattingEnabled = true;
            this.cboIva.Location = new System.Drawing.Point(432, 111);
            this.cboIva.Name = "cboIva";
            this.cboIva.Size = new System.Drawing.Size(121, 21);
            this.cboIva.TabIndex = 12;
            this.cboIva.SelectedIndexChanged += new System.EventHandler(this.cboIva_SelectedIndexChanged);
            // 
            // cboCliente
            // 
            this.cboCliente.FormattingEnabled = true;
            this.cboCliente.Location = new System.Drawing.Point(124, 109);
            this.cboCliente.Name = "cboCliente";
            this.cboCliente.Size = new System.Drawing.Size(121, 21);
            this.cboCliente.TabIndex = 11;
            this.cboCliente.SelectedIndexChanged += new System.EventHandler(this.CboCliente_SelectedIndexChanged);
            // 
            // lblCondIVA
            // 
            this.lblCondIVA.AutoSize = true;
            this.lblCondIVA.Location = new System.Drawing.Point(339, 112);
            this.lblCondIVA.Name = "lblCondIVA";
            this.lblCondIVA.Size = new System.Drawing.Size(74, 13);
            this.lblCondIVA.TabIndex = 3;
            this.lblCondIVA.Text = "Condicion IVA";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(31, 108);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(39, 13);
            this.lblCliente.TabIndex = 2;
            this.lblCliente.Text = "Cliente";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(31, 64);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(37, 13);
            this.lblFecha.TabIndex = 1;
            this.lblFecha.Text = "Fecha";
            // 
            // lblTipoFactura
            // 
            this.lblTipoFactura.AutoSize = true;
            this.lblTipoFactura.Location = new System.Drawing.Point(29, 20);
            this.lblTipoFactura.Name = "lblTipoFactura";
            this.lblTipoFactura.Size = new System.Drawing.Size(67, 13);
            this.lblTipoFactura.TabIndex = 0;
            this.lblTipoFactura.Text = "Tipo Factura";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(351, 225);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Precio";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(213, 225);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Cantidad";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 225);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Articulo";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 270);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Descuento";
            // 
            // cboArticulo
            // 
            this.cboArticulo.FormattingEnabled = true;
            this.cboArticulo.Location = new System.Drawing.Point(73, 222);
            this.cboArticulo.Name = "cboArticulo";
            this.cboArticulo.Size = new System.Drawing.Size(121, 21);
            this.cboArticulo.TabIndex = 12;
            this.cboArticulo.SelectedIndexChanged += new System.EventHandler(this.CboArticulo_SelectedIndexChanged);
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(281, 222);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(51, 20);
            this.txtCantidad.TabIndex = 14;
            this.txtCantidad.TextChanged += new System.EventHandler(this._txtCantidad_Leave);
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(407, 222);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(74, 20);
            this.txtPrecio.TabIndex = 15;
            // 
            // txtDescuento
            // 
            this.txtDescuento.Location = new System.Drawing.Point(96, 267);
            this.txtDescuento.Name = "txtDescuento";
            this.txtDescuento.Size = new System.Drawing.Size(90, 20);
            this.txtDescuento.TabIndex = 16;
            this.txtDescuento.TextChanged += new System.EventHandler(this.TxtDescuento_Leave);
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.AllowUserToDeleteRows = false;
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NroItem,
            this.CodArt,
            this.Descripocion,
            this.Cantidad,
            this.Precio,
            this.Importe});
            this.dgvDetalle.Location = new System.Drawing.Point(12, 303);
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.ReadOnly = true;
            this.dgvDetalle.Size = new System.Drawing.Size(683, 150);
            this.dgvDetalle.TabIndex = 17;
            this.dgvDetalle.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvDetalle_CellContentClick);
            // 
            // NroItem
            // 
            this.NroItem.HeaderText = "Nro. Item";
            this.NroItem.Name = "NroItem";
            this.NroItem.ReadOnly = true;
            // 
            // CodArt
            // 
            this.CodArt.HeaderText = "Cod. Art.";
            this.CodArt.Name = "CodArt";
            this.CodArt.ReadOnly = true;
            // 
            // Descripocion
            // 
            this.Descripocion.HeaderText = "Descripcion";
            this.Descripocion.Name = "Descripocion";
            this.Descripocion.ReadOnly = true;
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            // 
            // Precio
            // 
            this.Precio.HeaderText = "Precio";
            this.Precio.Name = "Precio";
            this.Precio.ReadOnly = true;
            // 
            // Importe
            // 
            this.Importe.HeaderText = "Importe";
            this.Importe.Name = "Importe";
            this.Importe.ReadOnly = true;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(139, 471);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 18;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.Location = new System.Drawing.Point(514, 471);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 23);
            this.btnGrabar.TabIndex = 19;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.BtnGrabar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(614, 471);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 20;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // btnQuitar
            // 
            this.btnQuitar.Location = new System.Drawing.Point(239, 471);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(75, 23);
            this.btnQuitar.TabIndex = 21;
            this.btnQuitar.Text = "Quitar";
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.BtnQuitar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(500, 225);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Importe";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(235, 270);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Sub Total";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(458, 270);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Total";
            // 
            // txtSubTotal
            // 
            this.txtSubTotal.Location = new System.Drawing.Point(327, 267);
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.Size = new System.Drawing.Size(98, 20);
            this.txtSubTotal.TabIndex = 25;
            // 
            // txtImporte
            // 
            this.txtImporte.Location = new System.Drawing.Point(561, 221);
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.Size = new System.Drawing.Size(82, 20);
            this.txtImporte.TabIndex = 26;
            this.txtImporte.TextChanged += new System.EventHandler(this.TextBox3_TextChanged);
            // 
            // txtImporteTotal
            // 
            this.txtImporteTotal.Location = new System.Drawing.Point(537, 267);
            this.txtImporteTotal.Name = "txtImporteTotal";
            this.txtImporteTotal.Size = new System.Drawing.Size(107, 20);
            this.txtImporteTotal.TabIndex = 27;
            // 
            // frmTransFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 500);
            this.Controls.Add(this.txtImporteTotal);
            this.Controls.Add(this.txtImporte);
            this.Controls.Add(this.txtSubTotal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnQuitar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.dgvDetalle);
            this.Controls.Add(this.txtDescuento);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.cboArticulo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Name = "frmTransFactura";
            this.Text = "frmTransFactura";
            this.Load += new System.EventHandler(this.FrmTransFactura_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblCondIVA;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblTipoFactura;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblNroFact;
        private System.Windows.Forms.Label lblVendedor;
        private System.Windows.Forms.ComboBox cboIva;
        private System.Windows.Forms.ComboBox cboCliente;
        private System.Windows.Forms.ComboBox cboArticulo;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.TextBox txtDescuento;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox txtNroFact;
        private System.Windows.Forms.ComboBox cboTipoFact;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSubTotal;
        private System.Windows.Forms.TextBox txtImporte;
        private System.Windows.Forms.TextBox txtImporteTotal;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn NroItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodArt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripocion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Importe;
    }
}