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
        public int idProducto { get; set; }

        public string Personaje { get; set; }

        public double Precio { get; set; }

        public int Cantidad { get; set; }

        public virtual int CategoriaidCategoria { get; set; }

        public virtual int TipoProductoidTipo { get; set; }

        public virtual List<Factura> FacturaListaVenta { get; set; } 
    }
}
