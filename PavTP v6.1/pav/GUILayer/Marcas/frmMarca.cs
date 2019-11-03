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

namespace pav.GUILayer.Marcas
{
    public partial class frmMarca : Form
    {
        private MarcaService oMarcaService;
        public frmMarca()
        {
            InitializeComponent();
            InitializeDataGridView();
            oMarcaService = new MarcaService();
        }

        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            String condiciones = "";
            var filters = new Dictionary<string, object>();

            if (!chkTodos.Checked)
            {
                

                // Validar si el textBox 'Nombre' esta vacio.
                if (txtMarca.Text != string.Empty)
                {
                    // Si el textBox tiene un texto no vacìo entonces recuperamos el valor del texto
                    filters.Add("nombre", txtMarca.Text);
                    condiciones += "AND nombre=" + "'" + txtMarca.Text + "'";
                }

                if (filters.Count > 0)
                    //SIN PARAMETROS
                    dgvMarcas.DataSource = oMarcaService.ConsultarConFiltrosSinParametros(condiciones);

                
                else
                    MessageBox.Show("Debe ingresar al menos un criterio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                dgvMarcas.DataSource = oMarcaService.ObtenerTodos();
        }


        private void InitializeDataGridView()
        {
            // Cree un DataGridView no vinculado declarando un recuento de columnas.
            dgvMarcas.ColumnCount = 2;
            dgvMarcas.ColumnHeadersVisible = true;

            // Configuramos la AutoGenerateColumns en false para que no se autogeneren las columnas
            dgvMarcas.AutoGenerateColumns = false;

            // Cambia el estilo de la cabecera de la grilla.
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();

            columnHeaderStyle.BackColor = Color.Beige;
            columnHeaderStyle.Font = new Font("Verdana", 8, FontStyle.Bold);
            dgvMarcas.ColumnHeadersDefaultCellStyle = columnHeaderStyle;

            // Definimos el nombre de la columnas y el DataPropertyName que se asocia a DataSource
            dgvMarcas.Columns[0].Name = "idMarca";
            dgvMarcas.Columns[0].DataPropertyName = "idMarca";
            // Definimos el ancho de la columna.


            dgvMarcas.Columns[1].Name = "Nombre";
            dgvMarcas.Columns[1].DataPropertyName = "Nombre";

            // Cambia el tamaño de la altura de los encabezados de columna.
            dgvMarcas.AutoResizeColumnHeadersHeight();

            // Cambia el tamaño de todas las alturas de fila para ajustar el contenido de todas las celdas que no sean de encabezado.
            dgvMarcas.AutoResizeRows(
                DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);
        }

        private void ChkTodos_CheckedChanged(object sender, EventArgs e)
        {
            
            if (chkTodos.Checked)
            {
                txtMarca.Enabled = false;
            }
            else
            {
                txtMarca.Enabled = true;
            }
            
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            frmABMMarca formulario = new frmABMMarca();
            formulario.ShowDialog();
            BtnConsultar_Click(sender, e);
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            frmABMMarca formulario = new frmABMMarca();
            var usuario = (Marca)dgvMarcas.CurrentRow.DataBoundItem;
            formulario.SeleccionarMarca(frmABMMarca.FormMode.update, usuario);
            formulario.ShowDialog();
            BtnConsultar_Click(sender, e);
        }

        private void BtnQuitar_Click(object sender, EventArgs e)
        {
            frmABMMarca formulario = new frmABMMarca();
            var usuario = (Marca)dgvMarcas.CurrentRow.DataBoundItem;
            formulario.SeleccionarMarca(frmABMMarca.FormMode.delete, usuario);
            formulario.ShowDialog();
            BtnConsultar_Click(sender, e);
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmMarca_Load(object sender, EventArgs e)
        {
            btnEditar.Enabled = false;
        }
    }
}
