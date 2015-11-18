using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BaseDatosBITland.ProyectoFinal
{
    public class Factura
    {
        [Key]
        public int IdFactura { get; set; }
        public int id { get; set; }
        public int cantidad { get; set; }
        public int total { get; set; }

    }
}
