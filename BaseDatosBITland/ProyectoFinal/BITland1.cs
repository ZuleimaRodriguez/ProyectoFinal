using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDatosBITland.ProyectoFinal
{
    public class BITland1 : DbContext{
        public DbSet<Cliente> Client { get; set; }
        public DbSet<Nivel> Nivel { get; set; }
        public DbSet<TipoProducto> TipoProducto { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Factura> Factura { get; set; }



    }

    

    }

