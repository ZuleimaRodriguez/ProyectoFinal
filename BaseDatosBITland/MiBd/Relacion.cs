using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BaseDatosBITland.MiBd
{
    public class Relacion
    {
        [Key]
        public int idRelacion { get; set; }
        public virtual int FacturaidFactura {get; set;}
        public virtual int ProductoidProducto { get; set; }

    }
}
