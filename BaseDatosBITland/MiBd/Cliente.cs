using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BaseDatosBITland.MiBd
{
    public class Cliente
    {
        [Key]
        public int idCliente { get; set; }
        public string Nombre { get; set; }
        public string Tienda { get; set; }
        public virtual string NivelNivel { get; set; }
        public string Direccion { get; set; }
        //public virtual ICollection<Factura> Facturas { get; set; }
    }
}
