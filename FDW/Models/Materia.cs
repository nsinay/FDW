using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FDW.Models
{
    public class Materia
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Marca { get; set; }
        public string Precio { get; set; }
        public string Existencia { get; set; }
    }
}
