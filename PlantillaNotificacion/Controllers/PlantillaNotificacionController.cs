using AutoMapper;
using EjemploPlantilla.DTO;
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
        public async Task<IActionResult> CrearPlantillaCtrl(PlantillaNotificacionDTOCreate plantillaDTO)
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
                var plantillaRgtoDTO = _mapper.Map<PlantillaNotificacionDTOCreate>(plantilla);
                return new JsonResult(plantillaRgtoDTO);
            }
            catch (Exception ex)
            {
                throw ex.InnerException!;
            }
        }

        //PUT: Controlador para modificar plantilla notificacion
        [HttpPut]
        [Route("Actualizar/(\"{id}\")")]
        public async Task<IActionResult> ActualizarPlantillaCtrl(PlantillaNotificacionUpdateDTO plantillaDTO)
        {
            try
            {
                var plantillaRgto = _mapper.Map<PlantillaNotificacion>(plantillaDTO);
                await _plantilla.ActualizarPlantilla(plantillaRgto);
                return NoContent();
            }catch(Exception ex)
            {
                throw ex.InnerException!;
            }
        }

        //DELETE: Controlador para eliminar plantilla notificacion
        [HttpDelete]
        [Route("Eliminar/(\"{id}\")")]
        public async Task<IActionResult> EliminarPlantillaCtrl(Guid id)
        {
            var plantillaDelete = _plantilla.ConsultarPlantillaGUID(id);

            if (plantillaDelete is not null)
            {
                await _plantilla.EliminarPlantilla(id);
                return Ok();
            }
            else
            {
                return NotFound();
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