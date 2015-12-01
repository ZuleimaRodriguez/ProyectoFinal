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
         public Factura ()
        {
            this.Tienda = new Cliente();
            this.ListaVenta = new List<Producto>();
        }
        [Key]

        public int idFactura { get; set; }

        public virtual Cliente Tienda { get; set; }

        public DateTime Fecha { get; set; }

        public virtual List<Producto> ListaVenta { get; set; } 

    }
}
