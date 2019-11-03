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

namespace pav.GUILayer.Usuarios
{
    public partial class frmUsuarios : Form
    {
        private UsuarioService oUsuarioService;
        private PerfilService oPerfilService;

        public frmUsuarios()
        {
            InitializeComponent();
            InitializeDataGridView();
            oUsuarioService = new UsuarioService();
            oPerfilService = new PerfilService();
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            LlenarCombo(cboPerfil, oPerfilService.ObtenerTodos(), "Nombre", "IdPerfil");
            this.CenterToParent();
            
        }

        private void LlenarCombo(ComboBox cbo, Object source, string display, String value)
        {
            cbo.DataSource = source;
            cbo.DisplayMember = display;
            cbo.ValueMember = value;
            cbo.SelectedIndex = -1;
        }

        private void InitializeDataGridView()
        {
            // Cree un DataGridView no vinculado declarando un recuento de columnas.
            dgvUsers.ColumnCount = 2;
            dgvUsers.ColumnHeadersVisible = true;

            // Configuramos la AutoGenerateColumns en false para que no se autogeneren las columnas
            dgvUsers.AutoGenerateColumns = false;

            // Cambia el estilo de la cabecera de la grilla.
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();

            columnHeaderStyle.BackColor = Color.Beige;
            columnHeaderStyle.Font = new Font("Verdana", 8, FontStyle.Bold);
            dgvUsers.ColumnHeadersDefaultCellStyle = columnHeaderStyle;

            // Definimos el nombre de la columnas y el DataPropertyName que se asocia a DataSource
            dgvUsers.Columns[0].Name = "Usuario";
            dgvUsers.Columns[0].DataPropertyName = "NombreUsuario";
            // Definimos el ancho de la columna.

            
            dgvUsers.Columns[1].Name = "Perfil";
            dgvUsers.Columns[1].DataPropertyName = "Perfil";

            // Cambia el tamaño de la altura de los encabezados de columna.
            dgvUsers.AutoResizeColumnHeadersHeight();

            // Cambia el tamaño de todas las alturas de fila para ajustar el contenido de todas las celdas que no sean de encabezado.
            dgvUsers.AutoResizeRows(
                DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            frmABMUsuario formulario = new frmABMUsuario();
            formulario.ShowDialog();
            BtnConsultar_Click(sender, e);
        }

        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            String condiciones = "";
            var filters = new Dictionary<string, object>();

            if (!chkTodos.Checked)
            {
                // Validar si el combo 'Perfiles' esta seleccionado.
                if (cboPerfil.Text != string.Empty)
                {
                    // Si el cbo tiene un texto no vacìo entonces recuperamos el valor de la propiedad ValueMember
                    filters.Add("idPerfil", cboPerfil.SelectedValue);
                    condiciones += " AND u.idperfil=" + cboPerfil.SelectedValue.ToString();

                }

                // Validar si el textBox 'Nombre' esta vacio.
                if (txtNombre.Text != string.Empty)
                {
                    // Si el textBox tiene un texto no vacìo entonces recuperamos el valor del texto
                    filters.Add("usuario", txtNombre.Text);
                    condiciones += "AND u.usuario=" + "'" + txtNombre.Text + "'";
                }

                if (filters.Count > 0)
                    //SIN PARAMETROS
                    dgvUsers.DataSource = oUsuarioService.ConsultarConFiltrosSinParametros(condiciones);

                //CON PARAMETROS
                //dgvUsers.DataSource = oUsuarioService.ConsultarConFiltrosConParametros(filters);

                else
                    MessageBox.Show("Debe ingresar al menos un criterio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                dgvUsers.DataSource = oUsuarioService.ObtenerTodos();

        }

        private void ChkTodos_CheckedChanged(object sender, EventArgs e)
        {
            {
                if (chkTodos.Checked)
                {
                    txtNombre.Enabled = false;
                    cboPerfil.Enabled = false;
                }
                else
                {
                    txtNombre.Enabled = true;
                    cboPerfil.Enabled = true;
                }
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            frmABMUsuario formulario = new frmABMUsuario();
            var usuario = (Usuario)dgvUsers.CurrentRow.DataBoundItem;
            formulario.SeleccionarUsuario(frmABMUsuario.FormMode.update, usuario);
            formulario.ShowDialog();
            BtnConsultar_Click(sender, e);
        }

        private void DgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEditar.Enabled = true;
            btnQuitar.Enabled = true;
        }

        private void BtnQuitar_Click(object sender, EventArgs e)
        {
            frmABMUsuario formulario = new frmABMUsuario();
            var usuario = (Usuario)dgvUsers.CurrentRow.DataBoundItem;
            formulario.SeleccionarUsuario(frmABMUsuario.FormMode.delete, usuario);
            formulario.ShowDialog();
            BtnConsultar_Click(sender, e);
        }

        private void PnlFiltros_Enter(object sender, EventArgs e)
        {

        }

        private void TxtNombre_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
