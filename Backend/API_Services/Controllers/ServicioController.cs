using API_Services.BLL.Service;
using API_Services.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicioController : ControllerBase
    {
        private readonly IServicioService _servicioService;

        public ServicioController(IServicioService servicioService)
        {
            _servicioService = servicioService;
        }

        [HttpGet]
        public async Task<IActionResult> ListarServicios()
        {
            try
            {
                IQueryable<VMServicio> queryServicios = await _servicioService.ObtenerTodos();

                List<VMServicio> Lista = queryServicios
                    .Select(s => new VMServicio()
                    {
                        IdServicio = s.IdServicio,
                        IdPerfil = s.IdPerfil,
                        IdCategoria = s.IdCategoria,
                        Servicio1 = s.Servicio1,
                        Precio = s.Precio,
                        Costo = s.Costo
                    }).ToList();

                return Ok(Lista);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error interno del servidor: " + ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerServicio(int id)
        {
            try
            {
                var servicio = await _servicioService.Obtener(id);

                if (servicio == null)
                {
                    return NotFound(new { message = "No se encontró ningún servicio con el ID especificado." });
                }

                var vmServicio = new VMServicio()
                {
                    IdServicio = servicio.IdServicio,
                    IdPerfil = servicio.IdPerfil,
                    IdCategoria = servicio.IdCategoria,
                    Servicio1 = servicio.Servicio1,
                    Precio = servicio.Precio,
                    Costo = servicio.Costo
                };

                return Ok(vmServicio);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error interno del servidor: " + ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertarServicio([FromBody] VMServicio model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest(new { message = "Los datos del servicio son nulos." });
                }


                bool respuesta = await _servicioService.Insertar(model);

                if (respuesta)
                {
                    return Ok(new { message = "Servicio insertado exitosamente." });
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error al insertar el servicio." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error interno del servidor: " + ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarServicio(int id, [FromBody] VMServicio model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest(new { message = "Los datos del servicio son nulos." });
                }

                var servicioExistente = await _servicioService.Obtener(id);

                if (servicioExistente == null)
                {
                    return NotFound(new { message = "No se encontró ningún servicio con el ID especificado." });
                }


                bool respuesta = await _servicioService.Actualizar(model);

                if (respuesta)
                {
                    return Ok(new { message = "Servicio actualizado exitosamente." });
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error al actualizar el servicio." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error interno del servidor: " + ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarServicio(int id)
        {
            try
            {

                bool respuesta = await _servicioService.Eliminar(id);

                if (respuesta)
                {
                    return Ok(new { message = "Servicio eliminado exitosamente." });
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error al eliminar el servicio." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error interno del servidor: " + ex.Message });
            }
        }
    }
}
