using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controller;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ProyectoTienda
{
    public partial class FrmPrincipal : Form
    {
        ProductsController PC;

        public static int ID;
        public static string Nombre, Descripcion, Precio = "";
        int fila, columna = 0;

        public FrmPrincipal()
        {
            InitializeComponent();
            PC = new ProductsController();
        }

        private void txtProductos_TextChanged(object sender, EventArgs e)
        {
            dtgvProductos.Visible = true;
            PC.Mostrar(dtgvProductos, txtProductos.Text);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Nombre = ""; Descripcion = ""; Precio = "";
            FrmNuevoProducto NewProduct = new FrmNuevoProducto();
            NewProduct.ShowDialog();
            txtProductos.Focus();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dtgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            fila = e.RowIndex; columna = e.ColumnIndex;
            switch (columna)
            {
                case 4:
                    {
                        ID = int.Parse(dtgvProductos.Rows[fila].Cells[0].Value.ToString());
                        //PC.Borrar(ID, dtgvProductos.Rows[fila].Cells[1].Value.ToString());
                        dtgvProductos.Visible = false;
                    }
                    break;
                case 5:
                    {
                        ID = int.Parse(dtgvProductos.Rows[fila].Cells[0].Value.ToString());
                        Nombre = dtgvProductos.Rows[fila].Cells[1].Value.ToString();
                        Descripcion = dtgvProductos.Rows[fila].Cells[2].Value.ToString();
                        Precio = dtgvProductos.Rows[fila].Cells[3].Value.ToString();
                        FrmNuevoProducto NewProduct = new FrmNuevoProducto();
                        NewProduct.ShowDialog();
                        dtgvProductos.Visible = false;
                    }
                    break;
            }
        }
    }
}
