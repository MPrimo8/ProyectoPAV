using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using pav.DataAcessLayer;
using pav.BusinessLayer;
using pav.Entities;


namespace pav.GUILayer.Articulos
{
    public partial class frmConsultaArt : Form
    {
        private readonly ArticuloService articuloService;
        public frmConsultaArt()
        {
            InitializeComponent();
            InitializeDataGridView();
            articuloService = new ArticuloService();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmConsultaArt_Load(object sender, EventArgs e)
        {
            LlenarCombo(cboMarcas, DBHelper.GetDBHelper().ConsultaSQL("SELECT idMarca, nombre FROM Marcas"), "nombre", "idMarca");
        }

        private void InitializeDataGridView()
        {
            // Cree un DataGridView no vinculado declarando un recuento de columnas.
            dgvArticulo.ColumnCount = 8;
            dgvArticulo.ColumnHeadersVisible = true;

            // Configuramos la AutoGenerateColumns en false para que no se autogeneren las columnas
            dgvArticulo.AutoGenerateColumns = false;

            // Cambia el estilo de la cabecera de la grilla.
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();

            columnHeaderStyle.BackColor = Color.Beige;
            columnHeaderStyle.Font = new Font("Verdana", 8, FontStyle.Bold);
            dgvArticulo.ColumnHeadersDefaultCellStyle = columnHeaderStyle;

            // Definimos el nombre de la columnas y el DataPropertyName que se asocia a DataSource
            dgvArticulo.Columns[0].Name = "ID";
            dgvArticulo.Columns[0].DataPropertyName = "idArticulo";
            // Definimos el ancho de la columna.
            dgvArticulo.Columns[0].Width = 50;

            dgvArticulo.Columns[1].Name = "Nombre";
            dgvArticulo.Columns[1].DataPropertyName = "nombre";

            dgvArticulo.Columns[2].Name = "Descripción";
            dgvArticulo.Columns[2].DataPropertyName = "descripcion";

            dgvArticulo.Columns[3].Name = "Marca";
            dgvArticulo.Columns[3].DataPropertyName = "Marca";

            dgvArticulo.Columns[4].Name = "Stock";
            dgvArticulo.Columns[4].DataPropertyName = "stock";

            dgvArticulo.Columns[5].Name = "Precio";
            dgvArticulo.Columns[5].DataPropertyName = "precio";

            dgvArticulo.Columns[6].Name = "Puntaje";
            dgvArticulo.Columns[6].DataPropertyName = "puntaje";

            dgvArticulo.Columns[7].Name = "Fecha Alta";
            dgvArticulo.Columns[7].DataPropertyName = "fechaAlta";

            // Cambia el tamaño de la altura de los encabezados de columna.
            dgvArticulo.AutoResizeColumnHeadersHeight();

            // Cambia el tamaño de todas las alturas de fila para ajustar el contenido de todas las celdas que no sean de encabezado.
            dgvArticulo.AutoResizeRows(
                DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);
        }

        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            var strSql = String.Concat("SELECT a.idArticulo, a.nombre," +
                "m.nombre AS Marca, a.descripcion, a.stock, a.precio, a.puntaje, a.fechaAlta, a.fechaHasta" +
                " FROM Articulos A JOIN Marcas M ON A.idMarca=M.idMarca WHERE 1=1");

            DateTime fechaDesde;
            DateTime fechaHasta;
            if (DateTime.TryParse(txtFechaAlta.Text, out fechaDesde) &&
                DateTime.TryParse(txtFechaHasta.Text, out fechaHasta) &&
                ((!string.IsNullOrEmpty(txtFechaAlta.Text)) || (!string.IsNullOrEmpty(txtFechaHasta.Text))))
            {
                strSql += " AND (fechaAlta>=" + txtFechaAlta.Text + " AND fechaBaja<=" + txtFechaHasta.Text + ")";
            }

            if (!string.IsNullOrEmpty(cboMarcas.Text))
            {
                var marca = cboMarcas.SelectedValue.ToString();
                strSql += "AND (m.nombre=" + marca + ") ";
            }

            if (!string.IsNullOrEmpty(cboTipoArt.Text))
            {
                var tipoArt = cboTipoArt.ToString();

                strSql += "AND (descripcion LIKE '%" + tipoArt + "%') ";

            }
                                 
            dgvArticulo.DataSource = DBHelper.GetDBHelper().ConsultaSQL(strSql);

            if (dgvArticulo.Rows.Count == 0)
            {
                MessageBox.Show("No se encontraron coincidencias para el/los filtros ingresados", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void LlenarCombo(ComboBox cbo, Object source, string display, String value)
        {
            // Datasource: establece el origen de datos de este objeto.
            cbo.DataSource = source;
            // DisplayMember: establece la propiedad que se va a mostrar para este ListControl.
            cbo.DisplayMember = display;
            // ValueMember: establece la ruta de acceso de la propiedad que se utilizará como valor real para los elementos de ListControl.
            cbo.ValueMember = value;
            //SelectedIndex: establece el índice que especifica el elemento seleccionado actualmente.
            cbo.SelectedIndex = -1;
        }

        private void BtnDetalle_Click(object sender, EventArgs e)
        {
            frmDetalleArt frmDetalle = new frmDetalleArt();
            Articulo selectedItem = (Articulo)dgvArticulo.CurrentRow.DataBoundItem;
            frmDetalle.InicializarDetalleArt(selectedItem.IdArticulo);
            frmDetalle.ShowDialog();
        }
    }
}
