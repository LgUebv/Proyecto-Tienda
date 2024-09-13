using ConexionChacarron;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Functions
    {
        Base b = new Base("localhost", "root", "", "tienda");

        public string Guardar(string q)
        {
            return b.comandos(q);
        }

        public DataSet Mostrar(string q, string tabla)
        {
            return b.Mostrar(q, tabla);
        }

        public string Borrar(string q)
        {
            return b.comandos(q);
        }

        public string Modificar(string q)
        {
            return b.comandos(q);
        }
        public string ObtenerDato(string q, string tabla, string campo)
        {
            return b.ObtenerDatos(q, tabla, campo);
        }
    }
}
