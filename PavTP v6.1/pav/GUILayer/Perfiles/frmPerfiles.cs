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

namespace pav.GUILayer.Perfiles
{
    public partial class frmPerfiles : Form
    {

        private PerfilService oPerfilService;

        public frmPerfiles()
        {
            InitializeComponent();
            oPerfilService = new PerfilService();
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            frmABMPerfil formulario = new frmABMPerfil();
            formulario.ShowDialog();
        }

        private void FrmPerfiles_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
            dgvPerf.DataSource = oPerfilService.ObtenerTodos();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnModif_Click(object sender, EventArgs e)
        {
            frmABMPerfil formulario = new frmABMPerfil();
            var perfil = (Perfil)dgvPerf.CurrentRow.DataBoundItem;
            formulario.SeleccionarPerfil(frmABMPerfil.FormMode.update, perfil);
            formulario.ShowDialog();
        }

        private void DgvPerf_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnModif.Enabled = true;
            btnBorrar.Enabled = true;
        }
        private void InitializeDataGridView()
        {
            // Cree un DataGridView no vinculado declarando un recuento de columnas.
            dgvPerf.ColumnCount = 1;
            dgvPerf.ColumnHeadersVisible = true;

            // Configuramos la AutoGenerateColumns en false para que no se autogeneren las columnas
            dgvPerf.AutoGenerateColumns = false;

            // Cambia el estilo de la cabecera de la grilla.
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();

            columnHeaderStyle.BackColor = Color.Beige;
            columnHeaderStyle.Font = new Font("Verdana", 8, FontStyle.Bold);
            dgvPerf.ColumnHeadersDefaultCellStyle = columnHeaderStyle;

            // Definimos el nombre de la columnas y el DataPropertyName que se asocia a DataSource
            dgvPerf.Columns[0].Name = "Nombre";
            dgvPerf.Columns[0].DataPropertyName = "Nombre";
            // Definimos el ancho de la columna.

            // Cambia el tamaño de la altura de los encabezados de columna.
            dgvPerf.AutoResizeColumnHeadersHeight();

            // Cambia el tamaño de todas las alturas de fila para ajustar el contenido de todas las celdas que no sean de encabezado.
            dgvPerf.AutoResizeRows(
                DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);
        }

        private void BtnBorrar_Click(object sender, EventArgs e)
        {
            frmABMPerfil formulario = new frmABMPerfil();
            var perfil = (Perfil)dgvPerf.CurrentRow.DataBoundItem;
            formulario.SeleccionarPerfil(frmABMPerfil.FormMode.delete, perfil);
            formulario.ShowDialog();
        }

    }
}
