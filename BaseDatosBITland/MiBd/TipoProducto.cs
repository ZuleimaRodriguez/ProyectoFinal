using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BaseDatosBITland.MiBd
{
    public class TipoProducto
    {
        [Key]
        public int idTipo { get; set; }
        public string Tipo { get; set; }

    }
}
