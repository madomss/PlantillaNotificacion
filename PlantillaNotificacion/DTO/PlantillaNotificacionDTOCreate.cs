using System.Runtime.InteropServices;

namespace EjemploPlantilla.DTO
{
    public class PlantillaNotificacionDTOCreate
    {
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public Guid? TipoEstadoId { get; set; }
    }
}
