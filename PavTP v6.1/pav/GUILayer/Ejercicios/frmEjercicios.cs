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

namespace pav.GUILayer.Ejercicios
{
    public partial class frmEjercicios : Form
    {
        private EjercicioService oEjercicioService;

        public frmEjercicios()
        {
            InitializeComponent();
            oEjercicioService = new EjercicioService();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            frmABMEjercicio formulario = new frmABMEjercicio();
            formulario.ShowDialog();
        }

        private void FrmEjercicios_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
            dgvEjerc.DataSource = oEjercicioService.ObtenerTodos();

            //LlenarCombo(cboMusculoAfectado, oEjercicioService.ObtenerTodos(), "Nombre", "MusculoAfectado");
            this.CenterToParent();
        }

        private void BtnModif_Click(object sender, EventArgs e)
        {
            frmABMEjercicio formulario = new frmABMEjercicio();
            var ejercicio = (Ejercicio)dgvEjerc.CurrentRow.DataBoundItem;
            formulario.SeleccionarEjercicio(frmABMEjercicio.FormMode.update, ejercicio);
            formulario.ShowDialog();
        }
        private void DgvEjerc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnModif.Enabled = true;
            btnBorrar.Enabled = true;
        }
        private void InitializeDataGridView()
        {
            // Cree un DataGridView no vinculado declarando un recuento de columnas.
            dgvEjerc.ColumnCount = 4;
            dgvEjerc.ColumnHeadersVisible = true;

            // Configuramos la AutoGenerateColumns en false para que no se autogeneren las columnas
            dgvEjerc.AutoGenerateColumns = false;

            // Cambia el estilo de la cabecera de la grilla.
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();

            columnHeaderStyle.BackColor = Color.Beige;
            columnHeaderStyle.Font = new Font("Verdana", 8, FontStyle.Bold);
            dgvEjerc.ColumnHeadersDefaultCellStyle = columnHeaderStyle;

            // Definimos el nombre de la columnas y el DataPropertyName que se asocia a DataSource
            dgvEjerc.Columns[0].Name = "Nombre";
            dgvEjerc.Columns[0].DataPropertyName = "Nombre";
            dgvEjerc.Columns[1].Name = "Descripcion";
            dgvEjerc.Columns[1].DataPropertyName = "Descripcion";
            dgvEjerc.Columns[2].Name = "Musculo Afectado";
            dgvEjerc.Columns[2].DataPropertyName = "MusculoAfectado";
            dgvEjerc.Columns[3].Name = "Dificultad";
            dgvEjerc.Columns[3].DataPropertyName = "Dificultad";
            // Definimos el ancho de la columna.

            // Cambia el tamaño de la altura de los encabezados de columna.
            dgvEjerc.AutoResizeColumnHeadersHeight();

            // Cambia el tamaño de todas las alturas de fila para ajustar el contenido de todas las celdas que no sean de encabezado.
            dgvEjerc.AutoResizeRows(
                DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);
        }

        private void BtnBorrar_Click(object sender, EventArgs e)
        {
            frmABMEjercicio formulario = new frmABMEjercicio();
            var ejercicio = (Ejercicio)dgvEjerc.CurrentRow.DataBoundItem;
            formulario.SeleccionarEjercicio(frmABMEjercicio.FormMode.delete, ejercicio);
            formulario.ShowDialog();
        }

        private void DgvEjerc_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            String condiciones = "";
            var filters = new Dictionary<string, object>();

            if (!chkTodos.Checked)
            {
                // Validar si el combo 'Musculo Afectado' esta seleccionado.
                if (cboMusculoAfectado.Text != string.Empty)
                {
                    // Si el cbo tiene un texto no vacìo entonces recuperamos el valor de la propiedad ValueMember
                    filters.Add("musculoAfectado", cboMusculoAfectado.SelectedValue);
                    condiciones += " AND e.musculoAfectado=" + cboMusculoAfectado.SelectedValue.ToString();

                }
                if (cboDificultad.Text != string.Empty)
                {
                    // Si el cbo tiene un texto no vacìo entonces recuperamos el valor de la propiedad ValueMember
                    filters.Add("dificultad", cboDificultad.SelectedValue);
                    condiciones += " AND e.dificultad=" + cboDificultad.SelectedValue.ToString();

                }

                // Validar si el textBox 'Nombre' esta vacio.
                if (txtNombre.Text != string.Empty)
                {
                    // Si el textBox tiene un texto no vacìo entonces recuperamos el valor del texto
                    filters.Add("nombre", txtNombre.Text);
                    condiciones += "AND e.nombre=" + "'" + txtNombre.Text + "'";
                }

                if (filters.Count > 0)
                    //SIN PARAMETROS
                    dgvEjerc.DataSource = oEjercicioService.ConsultarConFiltrosSinParametros(condiciones);

                //CON PARAMETROS
                //dgvUsers.DataSource = oUsuarioService.ConsultarConFiltrosConParametros(filters);

                else
                    MessageBox.Show("Debe ingresar al menos un criterio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                dgvEjerc.DataSource = oEjercicioService.ObtenerTodos();
        }
        private void ChkTodos_CheckedChanged(object sender, EventArgs e)
        {
            {
                if (chkTodos.Checked)
                {
                    txtNombre.Enabled = false;
                    cboMusculoAfectado.Enabled = false;
                    cboDificultad.Enabled = false;
                }
                else
                {
                    txtNombre.Enabled = true;
                    cboMusculoAfectado.Enabled = true;
                    cboDificultad.Enabled = true;
                }
            }
        }
        private void LlenarCombo(ComboBox cbo, Object source, string display, String value)
        {
            cbo.DataSource = source;
            cbo.DisplayMember = display;
            cbo.ValueMember = value;
            cbo.SelectedIndex = -1;
        }
    }
}
