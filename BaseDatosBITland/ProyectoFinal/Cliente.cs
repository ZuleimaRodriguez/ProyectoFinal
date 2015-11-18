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
        public virtual int Nivel { get; set; }
        public string Direccion { get; set; }
        public virtual ICollection<Factura> Factura { get; set; }
    }
}
