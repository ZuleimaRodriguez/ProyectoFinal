using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BaseDatosBITland.MiBd
{
    public class bit:DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<TipoProducto> Tipo { get; set; }
        public DbSet<Nivel> Niveles { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        
           }
}
