using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BaseDatosBITland.ProyectoFinal
{
    public class TipoProducto
    {
        [Key]
        public int idTipo {get; set;}
        public string Tipo { get; set; }
        public virtual ICollection<Producto> Productos { get; set; }

    }
}
