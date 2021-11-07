using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FDW.Models;

namespace FDW.Data
{
    public class FDWContext : DbContext
    {
        public FDWContext (DbContextOptions<FDWContext> options)
            : base(options)
        {
        }

        public DbSet<FDW.Models.Producto> Producto { get; set; }

        public DbSet<FDW.Models.Proveedores> Proveedores { get; set; }

        public DbSet<FDW.Models.Materia> Materia { get; set; }

        public DbSet<FDW.Models.Bodega> Bodega { get; set; }

        public DbSet<FDW.Models.ReportesMat> ReportesMat { get; set; }

        public DbSet<FDW.Models.ReportesProv> ReportesProv { get; set; }
    }
}
