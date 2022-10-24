using EjemploPlantilla.DTO;
using EjemploPlantilla.Persistence.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EjemploPlantilla.Persistence.DAO
{
    public interface IPlantillaNotificacionDAO
    {
        public List<PlantillaNotificacion> ConsultaPlantillas();
        public PlantillaNotificacion ConsultarPlantillaGUID(Guid id);
        public List<PlantillaNotificacion> ConsultarPlantillaTitulo(string titulo);
        //public List<PlantillaNotificacion> ConsultarPlantillaBody(PlantillaNotificacionDTO plantilla);
        public Task<PlantillaNotificacion> RegistroPlantilla(PlantillaNotificacion newPlantilla);
        public Task ActualizarPlantilla(PlantillaNotificacion plantilla);
        public Task EliminarPlantilla(Guid id);
    }
}
