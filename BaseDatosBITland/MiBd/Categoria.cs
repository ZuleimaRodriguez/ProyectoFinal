using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BaseDatosBITland.MiBd
{
    public class Categoria
    {
        [Key]
        public int idCategoria { get; set; }
        public string Categorias { get; set; }
        public virtual ICollection<Producto> Productos { get; set; }
    }
}
