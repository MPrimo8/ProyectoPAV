using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using pav.BusinessLayer;
using pav.Entities;

namespace pav.GUILayer.Transacciones
{
    public partial class frmTransFactura : Form
    {
        private readonly BindingList<FacturaDetalle> listaFacturaDetalle;
        private readonly FacturaService facturaService;
        private readonly ClienteService clienteService;
        private readonly ArticuloService articuloService;
        private readonly TipoFacturaService tipoFacturaService;

        public frmTransFactura()
        {
            InitializeComponent();
            dgvDetalle.AutoGenerateColumns = false;

            tipoFacturaService = new TipoFacturaService();
            facturaService = new FacturaService();
            clienteService = new ClienteService();
            articuloService = new ArticuloService();

            listaFacturaDetalle = new BindingList<FacturaDetalle>();

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void FrmTransFactura_Load(object sender, EventArgs e)
        {
            InicializarFormulario();
            LlenarCombo(cboCliente, clienteService.ObtenerTodos(), "Nombre", "IdCliente");
            LlenarCombo(cboArticulo, articuloService.ObtenerTodos(), "Nombre", "IdProducto");

            dgvDetalle.DataSource = listaFacturaDetalle;

            this.cboCliente.SelectedIndexChanged += new System.EventHandler(this.CboCliente_SelectedIndexChanged);
            this.cboArticulo.SelectedIndexChanged += new System.EventHandler(this.CboArticulo_SelectedIndexChanged);
        }

        private void LlenarCombo(ComboBox cbo, Object source, string display, String value)
        {
            cbo.ValueMember = value;
            cbo.DisplayMember = display;
            cbo.DataSource = source;
            cbo.SelectedIndex = -1;
        }

        private void InicializarFormulario()
        {

            btnAgregar.Enabled = false;
            txtDescuento.Text = (0).ToString("N2");
            txtNroFact.Text = "1";
            cboTipoFact.SelectedIndex = -1;
            txtNroFact.Text = "";

            cboCliente.SelectedIndex = -1;



            InicializarDetalle();

            dgvDetalle.DataSource = null;

        }

        private void InicializarDetalle()
        {
            cboArticulo.SelectedIndex = -1;
            txtCantidad.Text = "";
            txtPrecio.Text = 0.ToString("N2");
            txtImporte.Text = 0.ToString("N2");
        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void CboCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCliente.SelectedItem != null)
            {
                var cliente = (Cliente)cboCliente.SelectedItem;

            }
        }

        private void CboArticulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboArticulo.SelectedItem != null)
            {
                var producto = (Articulo)cboArticulo.SelectedItem;
                txtPrecio.Text = producto.Precio.ToString("C");
                txtCantidad.Enabled = true;
                int cantidad = 0;
                int.TryParse(txtCantidad.Text, out cantidad);
                txtImporte.Text = (producto.Precio * cantidad).ToString("C");
                btnAgregar.Enabled = true;
            }
            else
            {
                btnAgregar.Enabled = false;
                txtCantidad.Enabled = false;
                txtCantidad.Text = "";
                txtPrecio.Text = "";
                txtImporte.Text = "";
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            int cantidad = 0;
            int.TryParse(txtCantidad.Text, out cantidad);

            var articulo = (Articulo)cboArticulo.SelectedItem;
            listaFacturaDetalle.Add(new FacturaDetalle()
            {
                NroItem = listaFacturaDetalle.Count + 1,
                Articulo = articulo,
                Cantidad = cantidad,
                PrecioUnitario = articulo.Precio
            });

            CalcularTotales();

            InicializarDetalle();
        }

        private void CalcularTotales()
        {
            var subtotal = listaFacturaDetalle.Sum(p => p.Importe);
            txtSubTotal.Text = subtotal.ToString();

            double descuento = 0;
            double.TryParse(txtDescuento.Text, out descuento);

            var importeTotal = subtotal - subtotal * descuento / 100;
            txtImporteTotal.Text = importeTotal.ToString("C");
        }

        private void BtnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                var factura = new Factura
                {
                    Fecha = dtpFecha.Value,
                    Cliente = (Cliente)cboCliente.SelectedItem,
                    TipoFactura = (TipoFactura)cboTipoFact.SelectedItem,
                    FacturaDetalle = listaFacturaDetalle,
                    SubTotal = double.Parse(txtSubTotal.Text),
                    Descuento = double.Parse(txtDescuento.Text)
                };

                if (facturaService.ValidarDatos(factura))
                {
                    facturaService.Crear(factura);

                    MessageBox.Show(string.Concat("La factura nro: ", factura.IdFactura, " se generó correctamente."), "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    InicializarFormulario();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar la factura! " + ex.Message + ex.StackTrace, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void _txtCantidad_Leave(object sender, EventArgs e)
        {
            if (cboArticulo.SelectedItem != null)
            {
                int cantidad = 0;
                int.TryParse(txtCantidad.Text, out cantidad);
                var articulo = (Articulo)cboArticulo.SelectedItem;
                txtImporte.Text = (articulo.Precio * cantidad).ToString("C");
            }
        }

        private void TxtDescuento_Leave(object sender, EventArgs e)
        {
            CalcularTotales();
            double descuento = 0;
            if (double.TryParse(txtDescuento.Text, out descuento))
            {
                txtDescuento.Text = descuento.ToString("N2");
            }
        }

        private void DgvDetalle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BtnQuitar_Click(object sender, EventArgs e)
        {
            if (dgvDetalle.CurrentRow != null)
            {
                var detalleSeleccionado = (FacturaDetalle)dgvDetalle.CurrentRow.DataBoundItem;
                listaFacturaDetalle.Remove(detalleSeleccionado);
            }
        }

        private void cboIva_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
