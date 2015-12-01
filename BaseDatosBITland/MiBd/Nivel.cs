using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BaseDatosBITland.MiBd
{
    public class Nivel
    {
        [Key]
        public int idNivel { get; set; }
        public string Niveles { get; set; }
        //public virtual ICollection<Cliente> Clientes { get; set; }
    }
}
