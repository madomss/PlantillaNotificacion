using EjemploPlantilla.Persistence.Entities;

namespace EjemploPlantilla.DTO
{
    public class PlantillaNotificacionUpdateDTO
    {
        public Guid? Id { get; set; }
        public string? Titulo { get; set; }
        public string? Descripcion { get; set; }
        public Guid? TipoEstadoId { get; set; }
    }
}
