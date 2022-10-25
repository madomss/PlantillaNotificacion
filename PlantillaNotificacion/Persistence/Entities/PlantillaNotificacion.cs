using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace EjemploPlantilla.Persistence.Entities
{
    public class PlantillaNotificacion
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Descripcion { get; set; }
        public Guid? TipoEstadoId { get; set; }
        public TipoEstado? TipoEstado { get; set; }
    }
}
