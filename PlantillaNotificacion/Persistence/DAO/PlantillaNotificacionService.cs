using AutoMapper;
using EjemploPlantilla.DTO;
using EjemploPlantilla.Exceptions;
using EjemploPlantilla.Persistence.Database;
using EjemploPlantilla.Persistence.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EjemploPlantilla.Persistence.DAO
{
    public class PlantillaNotificacionService: IPlantillaNotificacionDAO
    {

        private readonly PlantillaDBContext _plantillaContext;
        private readonly IMapper _mapper;

        //CONSTRUCTOR
        public PlantillaNotificacionService(PlantillaDBContext plantillaContext, IMapper mapper)
        {
            _plantillaContext = plantillaContext;
            _mapper = mapper;
        }

        //GET: Controlador para consultar todas las plantillas
        public List<PlantillaNotificacion> ConsultaPlantillas()
        {
            var data = _plantillaContext.PlantillaNotificacion.Include(p => p.TipoEstado);
            return data.ToList();
        }

        //GET: Servicio para consultar una plantilla notificacion en especifico
        public PlantillaNotificacion ConsultarPlantillaGUID(Guid id)
        {
            var data = _plantillaContext.PlantillaNotificacion.Include(p => p.TipoEstado).Where(p => p.Id == id).Single();
            return data;
            //try
            //{
            //    var data = _plantillaContext.PlantillaNotificacion.Include(p => p.TipoEstado).Where(p => p.Id == id).Single();
            //    return data;
            //}catch(Exception ex)
            //{
            //    throw new InvalidOperationException("No se encontró plantilla por el ID: " + id + "no se encuentra registrado", ex);
            //}

        }

        //GET: Servicio para consultar una plantilla notificacion en especifico
        public List<PlantillaNotificacion> ConsultarPlantillaTitulo(string titulo)
        {
            var data = _plantillaContext.PlantillaNotificacion.Include(p => p.TipoEstado).Where(p => p.Titulo == titulo);
            return data.ToList();
        }

        //POST: Servicio para crear plantilla notificacion
        public async Task<PlantillaNotificacion> RegistroPlantilla(PlantillaNotificacion plantilla)
        {
            _plantillaContext.PlantillaNotificacion.Add(plantilla);
            await _plantillaContext.SaveChangesAsync();
            return plantilla;
        }

        //PUT: Servicio para crear plantilla notificacion
        public async Task ActualizarPlantilla(PlantillaNotificacion plantilla)
        {

            try
            {
                _plantillaContext.PlantillaNotificacion.Update(plantilla);
                var data = await _plantillaContext.SaveChangesAsync();
            }catch(Exception ex)
            {
                var mensaje = "No se pueden registrar campos vacios en el título o en la descripcion";
                throw new ExceptionsControl(mensaje);
            }
        }

        //DELETE: Servicio para eliminar plantilla notificacion
        public async Task EliminarPlantilla(Guid id)
        {
            var plantillaExist = ConsultarPlantillaGUID(id);

            if (plantillaExist is not null)
            {
                _plantillaContext.PlantillaNotificacion.Remove(plantillaExist);
                await _plantillaContext.SaveChangesAsync();
            }
        }

        //GET: Servicio para consultar una plantilla notificacion en especifico
        //public List<PlantillaNotificacionDTO> ConsultarPlantillaDTO(PlantillaNotificacionDTO plantilla)
        //{
        //    var plantillaRgto = _mapper.Map<PlantillaNotificacion>(plantilla);
        //    var data = _plantillaContext.PlantillaNotificacion.Include(p => p.TipoEstado).Where(p => p.Titulo == plantillaRgto.Titulo);
        //    return data.ToList();
        //}
    }
}
