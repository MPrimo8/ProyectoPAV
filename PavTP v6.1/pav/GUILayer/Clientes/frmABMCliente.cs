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

namespace pav.GUILayer.Clientes
{
    public partial class frmABMCliente : Form
    {
        private FormMode formMode = FormMode.insert;

        private readonly ClienteService oClienteService;
        private Cliente oClienteSelected;

        public frmABMCliente()
        {
            InitializeComponent();
            oClienteService = new ClienteService();
        }

        private void FrmABMCliente_Load(object sender, EventArgs e)
        {
            switch (formMode)
            {
                case FormMode.insert:
                    {
                        this.Text = "Nuevo Cliente";
                        break;
                    }

                case FormMode.update:
                    {
                        this.Text = "Actualizar Cliente";
                        // Recuperar usuario seleccionado en la grilla 
                        MostrarDatos();
                        txtNombre.Enabled = true;
                        txtApellido.Enabled = true;
                        txtPeso.Enabled = true;
                        txtPuntaje.Enabled = true;
                        txtApellido.Enabled = true;
                        break;
                    }

                case FormMode.delete:
                    {
                        MostrarDatos();
                        this.Text = "Habilitar/Deshabilitar Usuario";
                        txtNombre.Enabled = false;
                        txtApellido.Enabled = false;
                        txtPeso.Enabled = false;
                        txtPuntaje.Enabled = false;
                        txtApellido.Enabled = false;
                        break;
                    }
            }
        }

        public enum FormMode
        {
            insert,
            update,
            delete
        }

        public void SeleccionarCliente(FormMode op, Cliente clienteSelected)
        {
            formMode = op;
            oClienteSelected = clienteSelected;
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            switch (formMode)
            {
                case FormMode.insert:
                    {
                        
                        if (ValidarCampos())
                        {
                            var oCliente = new Cliente();
                            oCliente.Nombre = txtNombre.Text;
                            oCliente.Apellido = txtApellido.Text;
                            oCliente.Puntos = Convert.ToInt32(this.txtPuntaje.Text);
                            oCliente.Peso = Convert.ToDouble(this.txtPeso.Text);
                            oCliente.Altura = Convert.ToInt32(this.txtAltura.Text);
                            oCliente.Telefono = Convert.ToInt32(this.txtTelefono.Text);
                            oCliente.TelefonoEmerg = Convert.ToInt32(this.txtTelefonoEmerg.Text);



                            if (oClienteService.CrearCliente(oCliente))
                            {
                                MessageBox.Show("Cliente insertado!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                        }
                     
                        break;
                    }

                case FormMode.update:
                    {
                        if (ValidarCampos())
                        {
                            oClienteSelected.Nombre = txtNombre.Text;
                            oClienteSelected.Apellido = txtApellido.Text;
                            oClienteSelected.Puntos = Convert.ToInt32(txtPuntaje.Text);
                            oClienteSelected.Peso = Convert.ToDouble(this.txtPeso.Text);
                            oClienteSelected.Altura = Convert.ToInt32(this.txtAltura.Text);

                            if (oClienteService.ActualizarUsuario(oClienteSelected))
                            {
                                MessageBox.Show("Cliente actualizado!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Dispose();
                            }
                            else
                                MessageBox.Show("Error al actualizar el cliente!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        break;
                    }

                case FormMode.delete:
                    {
                        if (MessageBox.Show("Seguro que desea habilitar/deshabilitar el usuario seleccionado?", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {

                            if (oClienteService.ModificarEstadoCliente(oClienteSelected))
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
            if (txtApellido.Text == string.Empty)
            {
                txtApellido.BackColor = Color.Red;
                txtApellido.Focus();
                return false;
            }
            else
                txtApellido.BackColor = Color.White;
            if (txtTelefonoEmerg.Text == string.Empty)
            {
                txtTelefonoEmerg.BackColor = Color.Red;
                txtTelefonoEmerg.Focus();
                return false;
            }
            else
                txtTelefonoEmerg.BackColor = Color.White;


            return true;
        }
        /*
        private bool ExisteCliente()
        {
            return oClienteService.ObtenerCliente(txtNombre.Text) != null;
        }
        */
        private void MostrarDatos()
        {
            if (oClienteSelected != null)
            {
                txtNombre.Text = oClienteSelected.Nombre;
                txtApellido.Text = oClienteSelected.Apellido;
                txtPuntaje.Text = oClienteSelected.Puntos.ToString();
                txtPeso.Text = oClienteSelected.Peso.ToString();
                txtAltura.Text = oClienteSelected.Altura.ToString();
            }
        }
    }
}
