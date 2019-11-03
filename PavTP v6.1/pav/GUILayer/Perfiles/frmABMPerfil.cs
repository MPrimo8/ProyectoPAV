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

namespace pav.GUILayer.Perfiles
{
    public partial class frmABMPerfil : Form
    {
        private FormMode formMode = FormMode.insert;
        private readonly PerfilService oPerfilService;
        private Perfil oPerfilSelected;

        public frmABMPerfil()
        {
            InitializeComponent();
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


        private void FrmABMPerfil_Load(object sender, EventArgs e)
        {
            switch (formMode)
            {
                case FormMode.insert:
                    {
                        this.Text = "Nuevo Perfil";
                        break;
                    }

                case FormMode.update:
                    {
                        this.Text = "Actualizar Perfil";
                        // Recuperar usuario seleccionado en la grilla 
                        MostrarDatos();
                        txtNombre.Enabled = true;
                        break;
                    }

                case FormMode.delete:
                    {
                        MostrarDatos();
                        this.Text = "Habilitar/Deshabilitar Perfil";
                        txtNombre.Enabled = false;
                        break;
                    }
            }
        }
        private void MostrarDatos()
        {
            if (oPerfilSelected != null)
            {
                txtNombre.Text = oPerfilSelected.Nombre;
            }
        }
        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            switch (formMode)
            {
                case FormMode.insert:
                    {
                        if (ExistePerfil() == false)
                        {
                            if (ValidarCampos())
                            {
                                var oPerfil = new Perfil();
                                oPerfil.Nombre = txtNombre.Text;
                                //oUsuario.Perfil.IdPerfil = (int)cboPerfil.SelectedValue;

                                if (oPerfilService.CrearPerfil(oPerfil))
                                {
                                    MessageBox.Show("Perfil insertado!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                }
                            }
                        }
                        else
                            MessageBox.Show("Nombre de perfil encontrado!. Ingrese un nombre diferente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                case FormMode.update:
                    {
                        if (ValidarCampos())
                        {
                            oPerfilSelected.Nombre = txtNombre.Text;

                            if (oPerfilService.ActualizarPerfil(oPerfilSelected))
                            {
                                MessageBox.Show("Perfil actualizado!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Dispose();
                            }
                            else
                                MessageBox.Show("Error al actualizar el perfil!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        break;
                    }

                case FormMode.delete:
                    {
                        if (MessageBox.Show("Seguro que desea habilitar/deshabilitar el perfil seleccionado?", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {

                            if (oPerfilService.ModificarEstadoPerfil(oPerfilSelected))
                            {
                                MessageBox.Show("Perfil Habilitado/Deshabilitado!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            else
                                MessageBox.Show("Error al actualizar el Perfil!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;
                    }
            }
        }
        private bool ExistePerfil ()
        {
            return oPerfilService.ObtenerPerfil(txtNombre.Text) != null;
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
        public void SeleccionarPerfil(FormMode op, Perfil perfilSelected)
        {
            formMode = op;
            oPerfilSelected = perfilSelected;
        }
    }
}
