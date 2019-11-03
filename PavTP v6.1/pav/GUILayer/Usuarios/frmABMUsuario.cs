using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using pav.Entities;
using pav.BusinessLayer;

namespace pav.GUILayer.Usuarios
{
    public partial class frmABMUsuario : Form
    {
        private FormMode formMode = FormMode.insert;

        private readonly UsuarioService oUsuarioService;
        private readonly PerfilService oPerfilService;
        private Usuario oUsuarioSelected;

        public frmABMUsuario()
        {
            InitializeComponent();
            oUsuarioService = new UsuarioService();
            oPerfilService = new PerfilService();
        }
        public enum FormMode
        {
            insert,
            update,
            delete
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void frmABMUsuario_Load(object sender, EventArgs e)
        {
            LlenarCombo(cboPerfil, oPerfilService.ObtenerTodos(), "Nombre", "IdPerfil");
            switch (formMode)
            {
                case FormMode.insert:
                    {
                        this.Text = "Nuevo Usuario";
                        break;
                    }

                case FormMode.update:
                    {
                        this.Text = "Actualizar Usuario";
                        // Recuperar usuario seleccionado en la grilla 
                        MostrarDatos();
                        txtNombre.Enabled = true;
                        txtContraseña.Enabled = true;
                        txtValidar.Enabled = true;
                        cboPerfil.Enabled = true;
                        break;
                    }

                case FormMode.delete:
                    {
                        MostrarDatos();
                        this.Text = "Habilitar/Deshabilitar Usuario";
                        txtNombre.Enabled = false;
                        txtContraseña.Enabled = false;
                        txtValidar.Enabled = false;
                        cboPerfil.Enabled = false;
                        break;
                    }
            }

        }

        public void SeleccionarUsuario(FormMode op, Usuario usuarioSelected)
        {
            formMode = op;
            oUsuarioSelected = usuarioSelected;
        }

        private void MostrarDatos()
        {
            if (oUsuarioSelected != null)
            {
                txtNombre.Text = oUsuarioSelected.NombreUsuario;
                txtContraseña.Text = oUsuarioSelected.Contraseña;
                txtValidar.Text = txtContraseña.Text;
                cboPerfil.Text = oUsuarioSelected.Perfil.Nombre;
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            switch (formMode)
            {
                case FormMode.insert:
                    {
                        if (ExisteUsuario() == false)
                        {
                            if (ValidarCampos())
                            {
                                var oUsuario = new Usuario();
                                oUsuario.NombreUsuario = txtNombre.Text;
                                oUsuario.Contraseña = txtContraseña.Text;
                                oUsuario.Perfil = new Perfil();
                                oUsuario.Perfil.IdPerfil = (int)cboPerfil.SelectedValue;

                                if (oUsuarioService.CrearUsuario(oUsuario))
                                {
                                    MessageBox.Show("Usuario insertado!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                }
                            }
                        }
                        else
                            MessageBox.Show("Nombre de usuario encontrado!. Ingrese un nombre diferente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }

                case FormMode.update:
                    {
                        if (ValidarCampos())
                        {
                            oUsuarioSelected.NombreUsuario = txtNombre.Text;
                            oUsuarioSelected.Contraseña = txtContraseña.Text;
                            oUsuarioSelected.Perfil = new Perfil();
                            oUsuarioSelected.Perfil.IdPerfil = (int)cboPerfil.SelectedValue;

                            if (oUsuarioService.ActualizarUsuario(oUsuarioSelected))
                            {
                                MessageBox.Show("Usuario actualizado!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Dispose();
                            }
                            else
                                MessageBox.Show("Error al actualizar el usuario!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        break;
                    }

                case FormMode.delete:
                    {
                        if (MessageBox.Show("Seguro que desea habilitar/deshabilitar el usuario seleccionado?", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            
                            if (oUsuarioService.ModificarEstadoUsuario(oUsuarioSelected))
                            {
                                MessageBox.Show("Usuario Habilitado/Deshabilitado!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            else
                                MessageBox.Show("Error al actualizar el usuario!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        break;
                    }
            }

        }

        private bool ValidarCampos()
        {
            // campos obligatorios
            if (txtNombre.Text == string.Empty)
            {
                txtNombre.BackColor = Color.Red;
                txtNombre.Focus();
                return false;
            }
            else
                txtNombre.BackColor = Color.White;

            return true;
        }

        private bool ExisteUsuario()
        {
            return oUsuarioService.ObtenerUsuario(txtNombre.Text) != null;
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
