using AutoMapper;
using EjemploPlantilla.DTO;
using EjemploPlantilla.Exceptions;
using EjemploPlantilla.Mapper;
using EjemploPlantilla.Persistence.DAO;
using EjemploPlantilla.Persistence.Database;
using EjemploPlantilla.Persistence.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EjemploPlantilla.Controllers
{
    
    [Route("PlantillaNotificacion")]
    [ApiController]
    public class PlantillaNotificacionController:ControllerBase
    {
        private readonly IPlantillaNotificacionDAO _plantilla;
        private readonly IMapper _mapper;

        //CONSTRUCTOR
        public PlantillaNotificacionController(IPlantillaNotificacionDAO plantilla, IMapper mapper)
        {
            _mapper = mapper;
            _plantilla = plantilla;
        }

        //GET: Controlador para consultar todas las plantillas
        [HttpGet]
        [Route("Consulta/")]
        public List<PlantillaNotificacionSearchDTO> ConsultaPlantillasCtrl()
        {
            try
            {
                var plantilla = _plantilla.ConsultaPlantillas();
                var plantillaSearchDTO = _mapper.Map<List<PlantillaNotificacionSearchDTO>>(plantilla);
                return plantillaSearchDTO;
            }
            catch (Exception ex)
            {
                throw ex.InnerException!;
            }
        }

        //GET: Controlador para consultar una plantilla notificacion en especifico
        [HttpGet]
        [Route("Consulta/(\"{id}\")")]
        public ActionResult<PlantillaNotificacionSearchDTO> GetByGuidCtrl(Guid id)
        {
            var plantilla =  _plantilla.ConsultarPlantillaGUID(id);

            if (plantilla is null)
                return BadRequest(new { message = $"El ID ({id}) de la URL no coincide con algun ID" });

            var plantillaSearchDTO = _mapper.Map<PlantillaNotificacionSearchDTO>(plantilla);

            return plantillaSearchDTO;
        }

        [HttpGet]
        [Route("Consulta/Titulo/(\"{titulo}\")")]
        public List<PlantillaNotificacionSearchDTO> GetByTituloCtrl(string titulo)
        {
            try
            {
                var plantilla = _plantilla.ConsultarPlantillaTitulo(titulo);
                var plantillaSearchDTO = _mapper.Map<List<PlantillaNotificacionSearchDTO>>(plantilla);
                return plantillaSearchDTO;
            }
            catch(Exception ex)
            {
                throw ex.InnerException!;
            }
        }

        //POST: Controlador para crear plantilla notificacion
        [HttpPost]
        [Route("Registro/")]
        public async Task<Boolean> CrearPlantillaCtrl(PlantillaNotificacionDTOCreate plantillaDTO)
        {
            try
            {
                var a = new PlantillaNotificacion
                {
                    Id = Guid.NewGuid(),
                    Titulo = plantillaDTO.Titulo,
                    Descripcion = plantillaDTO.Descripcion,
                    TipoEstadoId = plantillaDTO.TipoEstadoId
                };
                var plantilla = await _plantilla.RegistroPlantilla(a);
                return plantilla;
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("No se pudo realizar el registro", ex);
            }
        }

        //PUT: Controlador para modificar plantilla notificacion
        [HttpPut]
        [Route("Actualizar/(\"{id}\")")]
        public async Task<Boolean> ActualizarPlantillaCtrl(PlantillaNotificacionUpdateDTO plantillaDTO)
        {
            try
            {
                //if (string.IsNullOrEmpty(plantillaDTO.Titulo) || string.IsNullOrEmpty(plantillaDTO.Descripcion))
                //{
                //    return BadRequest(new { message = $"El titulo y la descripción son campos requeridos." });
                //}
                var plantillaRgto = _mapper.Map<PlantillaNotificacion>(plantillaDTO);
                var plantilla = await _plantilla.ActualizarPlantilla(plantillaRgto);
                return plantilla;
            }catch(Exception ex)
            {
                var mensaje = "No se pueden registrar campos vacios en el título o en la descripcion";
                throw new ExceptionsControl(mensaje,ex);
            }
        }

        //DELETE: Controlador para eliminar plantilla notificacion
        [HttpDelete]
        [Route("Eliminar/(\"{id}\")")]
        public async Task<Boolean> EliminarPlantillaCtrl(Guid id)
        {
            try
            {
                var plantillaDelete = _plantilla.ConsultarPlantillaGUID(id);
                await _plantilla.EliminarPlantilla(id);
                return true;
            }catch (Exception ex)
            {
                var mensaje = "No se puede eliminar la plantilla notificación";
                throw new ExceptionsControl(mensaje,ex);
            }

        }

        //[HttpGet]
        //[Route("Consulta/Titulo/(\"{titulo}\")")]
        //public List<PlantillaNotificacion> GetByBody(PlantillaNotificacionDTO plantilla)
        //{
        //    try
        //    {
        //        List<PlantillaNotificacion> dto = new List<PlantillaNotificacion>();
        //        dto = _plantilla.ConsultarPlantillaBody(plantilla);
        //        return dto;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex.InnerException!;
        //    }
        //}
    }
}