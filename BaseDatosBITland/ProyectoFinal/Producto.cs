using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BaseDatosBITland.ProyectoFinal
{
    public class Producto
    {
        [Key]
        public int IdProducto { get; set; }
        public string Personaje { get; set; }
        public string categoria { get; set; }
        public string Tipo { get; set; }
        public int precio { get; set; }
    }
}
