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
using System.Data;
using pav.Entities;

namespace pav.GUILayer.Clientes
{
    public partial class frmClientes : Form
    {
        private ClienteService oClienteService;
        public frmClientes()
        {
            InitializeComponent();
            InitializeDataGridView();
            oClienteService = new ClienteService();
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
        }

        private void DgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEditar.Enabled = true;
            btnQuitar.Enabled = true;
        }
        private void InitializeDataGridView()
        {
            // Cree un DataGridView no vinculado declarando un recuento de columnas.
            dgvClientes.ColumnCount = 7;
            dgvClientes.ColumnHeadersVisible = true;

            // Configuramos la AutoGenerateColumns en false para que no se autogeneren las columnas
            dgvClientes.AutoGenerateColumns = false;

            // Cambia el estilo de la cabecera de la grilla.
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();

            columnHeaderStyle.BackColor = Color.Beige;
            columnHeaderStyle.Font = new Font("Verdana", 8, FontStyle.Bold);
            dgvClientes.ColumnHeadersDefaultCellStyle = columnHeaderStyle;

            // Definimos el nombre de la columnas y el DataPropertyName que se asocia a DataSource
            dgvClientes.Columns[0].Name = "Nombre";
            dgvClientes.Columns[0].DataPropertyName = "Nombre";
            // Definimos el ancho de la columna.


            dgvClientes.Columns[1].Name = "Apellido";
            dgvClientes.Columns[1].DataPropertyName = "Apellido";

            dgvClientes.Columns[2].Name = "Telefono";
            dgvClientes.Columns[2].DataPropertyName = "Telefono";

            dgvClientes.Columns[3].Name = "Telefono de Emergencia";
            dgvClientes.Columns[3].DataPropertyName = "TelefonoEmerg";

            dgvClientes.Columns[4].Name = "Peso";
            dgvClientes.Columns[4].DataPropertyName = "Peso";

            dgvClientes.Columns[5].Name = "Altura";
            dgvClientes.Columns[5].DataPropertyName = "Altura";

            dgvClientes.Columns[6].Name = "Puntaje";
            dgvClientes.Columns[6].DataPropertyName = "Puntaje";



            // Cambia el tamaño de la altura de los encabezados de columna.
            dgvClientes.AutoResizeColumnHeadersHeight();

            // Cambia el tamaño de todas las alturas de fila para ajustar el contenido de todas las celdas que no sean de encabezado.
            dgvClientes.AutoResizeRows(
                DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            String condiciones = "";
            var filters = new Dictionary<string, object>();

            if (!chkTodos.Checked)
            {
                                
                // Validar si el textBox 'Nombre' esta vacio.
                if (txtNombre.Text != string.Empty)
                {
                    // Si el textBox tiene un texto no vacìo entonces recuperamos el valor del texto
                    filters.Add("nombre", txtNombre.Text);
                    condiciones += "AND nombre=" + "'" + txtNombre.Text + "'";
                }

                if (txtApellido.Text != string.Empty)
                {
                    // Si el textBox tiene un texto no vacìo entonces recuperamos el valor del texto
                    filters.Add("apellido", txtApellido.Text);
                    condiciones += "AND apellido=" + "'" + txtApellido.Text + "'";
                }

                if (filters.Count > 0)
                    //SIN PARAMETROS
                    dgvClientes.DataSource = oClienteService.ConsultarConFiltrosSinParametros(condiciones);

                //CON PARAMETROS
                //dgvUsers.DataSource = oUsuarioService.ConsultarConFiltrosConParametros(filters);

                else
                    MessageBox.Show("Debe ingresar al menos un criterio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                dgvClientes.DataSource = oClienteService.ObtenerTodos();
        }

        private void ChkTodos_CheckedChanged(object sender, EventArgs e)
        {
            
            if (chkTodos.Checked)
            {
                txtNombre.Enabled = false;
                txtApellido.Enabled = false;
            }
            else
            {
                txtNombre.Enabled = true;
                txtApellido.Enabled = true;
            }
            
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            frmABMCliente formulario = new frmABMCliente();
            formulario.ShowDialog();
            Button1_Click(sender, e);
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            frmABMCliente formulario = new frmABMCliente();
            var cliente = (Cliente)dgvClientes.CurrentRow.DataBoundItem;
            formulario.SeleccionarCliente(frmABMCliente.FormMode.update, cliente);
            formulario.ShowDialog();
            Button1_Click(sender, e);
        }

        private void BtnQuitar_Click(object sender, EventArgs e)
        {
            frmABMCliente formulario = new frmABMCliente();
            var cliente = (Cliente)dgvClientes.CurrentRow.DataBoundItem;
            formulario.SeleccionarCliente(frmABMCliente.FormMode.delete, cliente);
            formulario.ShowDialog();
            Button1_Click(sender, e);
        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
