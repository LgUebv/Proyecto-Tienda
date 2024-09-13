using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using System.Windows.Forms;
using System.Drawing;

namespace Controller
{
    public class ProductsController
    {
        Functions f = new Functions();


        public void Guardar(TextBox Nombre, TextBox Descripcion, TextBox Precio)
        {
            MessageBox.Show(f.Guardar($"call p_insertar ('{Nombre.Text}', '{Descripcion.Text}', {Precio.Text})"),
                "Atencion!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void Modificar(TextBox Nombre, TextBox Descripcion, TextBox Precio, int ID)
        {
            MessageBox.Show(f.Modificar($"call p_modificar ({ID}, '{Nombre.Text}', '{Descripcion.Text}', {Precio.Text})"),
                "Atencion!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void Borrar(int ID, string dato)
        {
            DialogResult rs = MessageBox.Show($"Estas seguro de borrar {dato}?", "Atencion!!",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                f.Borrar($"call p_Eliminar ({ID})");
                MessageBox.Show("Registro eliminado con exito", "Atencion!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        DataGridViewButtonColumn Boton(string t, Color fondo)
        {
            DataGridViewButtonColumn b = new DataGridViewButtonColumn();
            b.Text = t;
            b.UseColumnTextForButtonValue = true;
            b.FlatStyle = FlatStyle.Popup;
            b.DefaultCellStyle.BackColor = fondo;
            b.DefaultCellStyle.ForeColor = Color.White;
            return b;
        }

        public void Mostrar(DataGridView tabla, string filtro)
        {
            tabla.Columns.Clear();
            tabla.DataSource = f.Mostrar($"select * from Productos where Nombre like '%{filtro}%'", "Productos").Tables[0];
            tabla.Columns.Insert(4, Boton("Borrar", Color.Red));
            tabla.Columns.Insert(5, Boton("Editar", Color.Green));
            tabla.AutoResizeColumns();
            tabla.AutoResizeRows();
        }
    }
}
