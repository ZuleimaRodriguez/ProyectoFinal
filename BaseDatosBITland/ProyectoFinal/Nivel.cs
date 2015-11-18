using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BaseDatosBITland.ProyectoFinal
{
    public class Nivel
    {
        [Key]
        public int IdNivel { get; set; }
        public int nivel { get; set; }

    }
}
