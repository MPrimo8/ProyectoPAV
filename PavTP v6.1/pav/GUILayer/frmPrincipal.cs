using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using pav.GUILayer.Login;
using pav.GUILayer.Usuarios;
using pav.GUILayer.Articulos;
using pav.GUILayer.Clientes;
using pav.GUILayer.Perfiles;
using pav.GUILayer.Marcas;
using pav.GUILayer.Ejercicios;
using pav.GUILayer.Transacciones;


namespace pav
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            
            frmLogin login = new frmLogin();
            login.ShowDialog();
            
        }

        private void UsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsuarios frmDetalle = new frmUsuarios();
            frmDetalle.ShowDialog();
        }

        private void ConsultarArticulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsultaArt frmDetalle = new frmConsultaArt();
            frmDetalle.ShowDialog();
        }

        private void ClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmClientes frmDetalle = new frmClientes();
            frmDetalle.ShowDialog();
        }

        private void PerfilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPerfiles frmDetalle = new frmPerfiles();
            frmDetalle.ShowDialog();
        }

        private void MarcasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMarca frmDetalle = new frmMarca();
            frmDetalle.ShowDialog();
        }

        private void EjerciciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEjercicios frmDetalle = new frmEjercicios();
            frmDetalle.ShowDialog();
        }

        private void VentaArticulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTransFactura frmDetalle = new frmTransFactura();
            frmDetalle.ShowDialog();
        }
    }
}
