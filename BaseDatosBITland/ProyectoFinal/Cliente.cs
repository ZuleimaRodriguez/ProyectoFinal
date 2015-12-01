using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;

namespace BaseDatosBITland.ProyectoFinal
{
    public class Cliente
    {
        [Key]
        public int idCliente { get; set; }
        public string Tienda { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public virtual ICollection<Factura> facturas { get; set; }
    }
}
