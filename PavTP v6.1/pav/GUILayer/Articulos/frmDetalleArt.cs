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

namespace pav.GUILayer.Articulos
{
    
    public partial class frmDetalleArt : Form
    {
        private ArticuloService articuloService;

        public frmDetalleArt()
        {
            InitializeComponent();
            articuloService = new ArticuloService();
        }

        internal void InicializarDetalleArt(int idArticulo)
        {


            var resultado = articuloService.ConsultarArticuloPorId(idArticulo);

            if (resultado != null)
            {
                txtId.Text = resultado.IdArticulo.ToString();
                txtNombre.Text = resultado.Nombre;
                txtDescripcion.Text = resultado.Descripcion;
                txtFechaAlta.Text = resultado.FechaAlta.ToString();
                txtPrecio.Text = resultado.Precio.ToString();
                txtPuntaje.Text = resultado.Puntaje.ToString();
                txtMarca.Text = resultado.Marca.Nombre;
               
            }
           
        }

        private void FrmDetalleArt_Load(object sender, EventArgs e)
        {

        }
    }
}
