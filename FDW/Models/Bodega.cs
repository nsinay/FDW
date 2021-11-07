using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FDW.Models
{
    public class Bodega
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Cantidad { get; set; }
        public string Precio { get; set; }
        public DateTime Fecha { get; set; }
    }
}
