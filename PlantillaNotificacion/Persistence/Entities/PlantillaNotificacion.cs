using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace EjemploPlantilla.Persistence.Entities
{
    public class PlantillaNotificacion
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public Guid? TipoEstadoId { get; set; }
        public TipoEstado? TipoEstado { get; set; }
    }
}
