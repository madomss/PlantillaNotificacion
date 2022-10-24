using EjemploPlantilla.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace EjemploPlantilla.Persistence.Database
{
    public interface IPlantillaDBContext
    {
        DbContext DbContext
        {
            get;
        }
        DbSet<PlantillaNotificacion> PlantillaNotificacion
        {
            get; set; 
        }
        DbSet<Estado> Estado
        {
            get; set;
        }
    }
}
