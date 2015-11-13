using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDatosBITland.ProyectoFinal
{
    public class BITland : DbContext{
        public DbSet<Cliente> Client { get; set; }
    }

    

    }

