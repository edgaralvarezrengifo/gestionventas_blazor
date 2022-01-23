using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#nullable disable

namespace PruebaGestionVentas.Server.Models
{
    public  class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

   
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

       

        public DbSet<Producto>Producto{get;set;}
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Venta> Venta { get; set; }
        public DbSet<Venta_detalle> Venta_detalle { get; set; }
    }
}
