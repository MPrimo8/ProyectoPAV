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

namespace pav.GUILayer.Ejercicios
{
    public partial class frmABMEjercicio : Form
    {
        private FormMode formMode = FormMode.insert;
        private readonly EjercicioService oEjercicioService;
        private Ejercicio oEjercicioSelected;
        public frmABMEjercicio()
        {
            InitializeComponent();
            oEjercicioService = new EjercicioService();
        }
        public enum FormMode
        {
            insert,
            update,
            delete
        }
        public void SeleccionarEjercicio(FormMode op, Ejercicio EjercicioSelected)
        {
            formMode = op;
            oEjercicioSelected = EjercicioSelected;
        }
        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmABMEjercicio_Load(object sender, EventArgs e)
        {
            switch (formMode)
            {
                case FormMode.insert:
                    {
                        this.Text = "Nuevo Ejercicio";
                        break;
                    }

                case FormMode.update:
                    {
                        this.Text = "Actualizar Ejercicio";
                        // Recuperar usuario seleccionado en la grilla 
                        MostrarDatos();
                        txtNombre.Enabled = true;
                        txtDescripcion.Enabled = true;
                        txtMusc.Enabled = true;
                        txtDificultad.Enabled = true;
                        break;
                    }

                case FormMode.delete:
                    {
                        MostrarDatos();
                        this.Text = "Habilitar/Deshabilitar Ejercicio";
                        txtNombre.Enabled = false;
                        txtDescripcion.Enabled = false;
                        txtMusc.Enabled = false;
                        txtDificultad.Enabled = false;
                        break;
                    }
            }
        }
        private void MostrarDatos()
        {
            if (oEjercicioSelected != null)
            {
                txtNombre.Text = oEjercicioSelected.Nombre;
                txtDescripcion.Text = oEjercicioSelected.Descripcion;
                txtMusc.Text = oEjercicioSelected.MusculoAfectado;
                txtDificultad.Text = oEjercicioSelected.Dificultad;
            }
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            switch (formMode)
            {
                case FormMode.insert:
                    {
                        if (ExisteEjercicio() == false)
                        {
                            if (ValidarCampos())
                            {
                                var oEjercicio = new Ejercicio();
                                oEjercicio.Nombre = txtNombre.Text;
                                oEjercicio.Descripcion = txtDescripcion.Text;
                                oEjercicio.MusculoAfectado = txtMusc.Text;
                                oEjercicio.Dificultad = txtDificultad.Text;
                                //oUsuario.Perfil.IdPerfil = (int)cboPerfil.SelectedValue;

                                if (oEjercicioService.CrearEjercicio(oEjercicio))
                                {
                                    MessageBox.Show("Ejercicio insertado!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                }
                            }
                        }
                        else
                            MessageBox.Show("Nombre de Ejercicio encontrado!. Ingrese un nombre diferente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                case FormMode.update:
                    {
                        if (ValidarCampos())
                        {
                            oEjercicioSelected.Nombre = txtNombre.Text;
                            oEjercicioSelected.Descripcion = txtDescripcion.Text;
                            oEjercicioSelected.MusculoAfectado = txtMusc.Text;
                            oEjercicioSelected.Dificultad = txtDificultad.Text;

                            if (oEjercicioService.ActualizarEjercicio(oEjercicioSelected))
                            {
                                MessageBox.Show("Ejercicio actualizado!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Dispose();
                            }
                            else
                                MessageBox.Show("Error al actualizar el Ejercicio!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        break;
                    }

                case FormMode.delete:
                    {
                        if (MessageBox.Show("Seguro que desea habilitar/deshabilitar el ejercicio seleccionado?", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {

                            if (oEjercicioService.ModificarEstadoEjercicio(oEjercicioSelected))
                            {
                                MessageBox.Show("Ejercicio Habilitado/Deshabilitado!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            else
                                MessageBox.Show("Error al actualizar el Ejercicio!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;
                    }
            }
        }
        private bool ExisteEjercicio()
        {
            return oEjercicioService.ObtenerEjercicio(txtNombre.Text) != null;
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
    }
}
