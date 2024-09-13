using Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoTienda
{
    public partial class FrmNuevoProducto : Form
    {
        ProductsController PC;
        public FrmNuevoProducto()
        {
            InitializeComponent();
            PC = new ProductsController();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (FrmPrincipal.ID > 0)
            {
                //PC.Modificar(txtUsername, txtPassword, txtNombre, txtApellidos, cmbNivel, FrmMenu.ID);
            }
            else
            {
                PC.Guardar(txtNombre, txtDescripcion, txtPrecio);
            }
            Close();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
