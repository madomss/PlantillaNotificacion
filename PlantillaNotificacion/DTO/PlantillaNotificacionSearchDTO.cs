using EjemploPlantilla.Persistence.Entities;

namespace EjemploPlantilla.DTO
{
    public class PlantillaNotificacionSearchDTO
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public TipoEstado TipoEstado { get; set; }
    }
}
