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
        [Key]
        public int idFactura { get; set; }
        public int Cantidad { get; set; }
        public virtual int ClienteidCliente { get; set; }
        public virtual ICollection<Relacion> Relaciones { get; set; }

    }
}
