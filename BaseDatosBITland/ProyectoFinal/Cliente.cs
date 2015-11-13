using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BaseDatosBITland.ProyectoFinal
{
    public class Cliente
    {
        public int id { get; set; }
        public string Tienda { get; set; }
        public string Nombre { get; set; }
        public string Nivel { get; set; }
        public string Direccion { get; set; }
    }
}
