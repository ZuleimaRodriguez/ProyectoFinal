using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BaseDatosBITland.MiBd
{
    
   public class Producto
    {
       [Key]
       public int idProducto { get; set; }
       public string Personaje { get; set; }
       public int Precio { get; set; }
       public virtual string TipoProductoTipo { get; set; }
       public virtual string CategoriaCategoria { get; set; }
       public virtual ICollection<Relacion> Relaciones { get; set; }
    }
}
