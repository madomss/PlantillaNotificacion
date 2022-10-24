using Microsoft.EntityFrameworkCore;
using EjemploPlantilla.Persistence.Entities;
using System.Net.Sockets;

namespace EjemploPlantilla.Persistence.Database
{
    public class PlantillaDBContext : DbContext, IPlantillaDBContext
    {
        public PlantillaDBContext(DbContextOptions<PlantillaDBContext> options) : base(options){}

        public DbSet<PlantillaNotificacion> PlantillaNotificacion { get; set; }
        public DbSet<TipoEstado> TipoEstado { get; set;}
        public DbSet<Estado> Estado { get; set; }

        public DbContext DbContext { get; }
    }
}
