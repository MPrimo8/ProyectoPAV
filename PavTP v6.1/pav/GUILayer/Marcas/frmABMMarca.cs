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
using pav.DataAcessLayer;

namespace pav.GUILayer.Marcas
{
    public partial class frmABMMarca : Form
    {
        private FormMode formMode = FormMode.insert;

        private readonly MarcaService oMarcaService;

        private Marca oMarcaSelected;
        public frmABMMarca()
        {
            InitializeComponent();
            oMarcaService = new MarcaService();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            switch (formMode)
            {
                case FormMode.insert:
                    {
                        if ((ExisteMarca()) == false)
                        {
                            if (ValidarCampos())
                            {
                                var oMarca = new Marca();
                                oMarca.Nombre = txtMarca.Text;
                                

                                if (oMarcaService.CrearMarca(oMarca))
                                {
                                    MessageBox.Show("Marca insertada!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                }
                            }
                        }
                        else
                            MessageBox.Show("Nombre de Marca encontrado!. Ingrese un nombre diferente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }

                case FormMode.update:
                    {
                        if (ValidarCampos())
                        {
                            oMarcaSelected.Nombre = txtMarca.Text;
                            

                            if (oMarcaService.ActualizarMarca(oMarcaSelected))
                            {
                                MessageBox.Show("Marca actualizada!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Dispose();
                            }
                            else
                                MessageBox.Show("Error al actualizar la Marca!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        break;
                    }

                case FormMode.delete:
                    {
                        if (MessageBox.Show("Seguro que desea habilitar/deshabilitar la marca seleccionada?", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {

                            if (oMarcaService.ModificarEstadoMarca(oMarcaSelected))
                            {
                                MessageBox.Show("Marca Habilitado/Deshabilitado!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            else
                                MessageBox.Show("Error al actualizar la marca!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        break;
                    }
            }
        }

        private bool ExisteMarca()
        {
            return oMarcaService.ObtenerMarca(txtMarca.Text) != null;
        }

        public enum FormMode
        {
            insert,
            update,
            delete
        }

        
        private void FrmABMMarca_Load(object sender, EventArgs e)
        {
            switch (formMode)
            {
                case FormMode.insert:
                    {
                        this.Text = "Nueva Marca";
                        break;
                    }

                case FormMode.update:
                    {
                        this.Text = "Actualizar Marca";
                        // Recuperar usuario seleccionado en la grilla 
                        MostrarDatos();
                        txtMarca.Enabled = true;

                        break;
                    }

                case FormMode.delete:
                    {
                        MostrarDatos();
                        this.Text = "Habilitar/Deshabilitar Marca";
                        txtMarca.Enabled = false;
                        break;

                    }
            }
        }

        private void MostrarDatos()
        {
            if (oMarcaSelected != null)
            {
                txtMarca.Text = oMarcaSelected.Nombre;
                
            }
        }

        public void SeleccionarMarca(FormMode op, Marca marcaSelected)
        {
            formMode = op;
            oMarcaSelected = marcaSelected;
        }

        private bool ValidarCampos()
        {
            // campos obligatorios
            if (txtMarca.Text == string.Empty)
            {
                txtMarca.BackColor = Color.Red;
                txtMarca.Focus();
                return false;
            }
            else
                txtMarca.BackColor = Color.White;

            return true;
        }
    }
}
