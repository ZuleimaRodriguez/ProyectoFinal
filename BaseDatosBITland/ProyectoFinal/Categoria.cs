using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BaseDatosBITland.ProyectoFinal
{
    public class Categoria
    {
        [Key]
        public int idCategoria { get; set; }
        public string Cate { get; set; }
        public virtual ICollection<Producto> Productos { get; set; }
    }
}
