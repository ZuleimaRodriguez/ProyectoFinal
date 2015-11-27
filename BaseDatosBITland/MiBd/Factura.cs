using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BaseDatosBITland.MiBd
{
    public class Factura

    {
        public Factura()
        {
            this.ClienteidCliente = new Cliente();
            this.listVenta = new List<Producto>();
        }

        [Key]
        public int idFactura { get; set; }
        public DateTime Fecha { get; set; }
        public virtual Cliente ClienteidCliente { get; set; }
        public virtual List<Producto> listVenta { get; set; }
    }
}
