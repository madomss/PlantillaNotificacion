using AutoMapper;
using EjemploPlantilla.DTO;
using EjemploPlantilla.Persistence.Entities;

namespace EjemploPlantilla.Mapper
{
    public class PlantillaNotificacionMapper:Profile
    {
        public PlantillaNotificacionMapper()
        {
            CreateMap<PlantillaNotificacionDTOCreate, PlantillaNotificacion>();
            CreateMap<PlantillaNotificacion, PlantillaNotificacionDTOCreate>();

            CreateMap<PlantillaNotificacion, PlantillaNotificacionUpdateDTO>();
            CreateMap<PlantillaNotificacionUpdateDTO, PlantillaNotificacion>();
            
            CreateMap<PlantillaNotificacion, PlantillaNotificacionSearchDTO>();
            CreateMap<PlantillaNotificacionSearchDTO, PlantillaNotificacion>();

            CreateMap<PlantillaNotificacion, List<PlantillaNotificacionSearchDTO>>();
            CreateMap<List<PlantillaNotificacionSearchDTO>, PlantillaNotificacion>();


            CreateMap<TipoEstadoDTO, TipoEstado>();
            CreateMap<TipoEstado, TipoEstadoDTO>();
        }
    }
}
