using API_Services.BLL.Service;
using API_Services.Models.ViewModels;
using API_Services.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace API_Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatosBasicoController : ControllerBase
    {
        private readonly IDatosBasicoService _datosBasicoService;

        public DatosBasicoController(IDatosBasicoService datosBasicoService)
        {
            _datosBasicoService = datosBasicoService;
        }

        [HttpGet]
        public async Task<IActionResult> ListarDatosBasicos()
        {
            try
            {
                IQueryable<DatosBasico> queryDatosSQL = await _datosBasicoService.ObtenerTodos();

                List<VMDatosBasico> Lista = queryDatosSQL
                    .Select(c => new VMDatosBasico()
                    {
                        IdDatos = c.IdDatos,
                        IdPerfil = c.IdPerfil,
                        IdUsuarios = c.IdUsuarios,
                        Nombres = c.Nombres,
                        Apellidos = c.Apellidos,
                        Idnacional = c.Idnacional,
                        Direccion = c.Direccion,
                        Celular = c.Celular,
                        TelfLocal = c.TelfLocal,
                        Referidos = c.Referidos,
                        Calificacion = c.Calificacion
                    }).ToList();

                return StatusCode(StatusCodes.Status200OK, Lista);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error interno del servidor: " + ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertarDatos([FromBody] VMDatosBasico model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest(new { message = "Los datos básicos son nulos." });
                }

                DatosBasico nuevoModelo = new DatosBasico()
                {
                    IdPerfil = model.IdPerfil,
                    IdUsuarios = model.IdUsuarios,
                    Nombres = model.Nombres,
                    Apellidos = model.Apellidos,
                    Idnacional = model.Idnacional,
                    Direccion = model.Direccion,
                    Celular = model.Celular,
                    TelfLocal = model.TelfLocal,
                    Referidos = model.Referidos,
                    Calificacion = model.Calificacion
                };

                bool respuesta = await _datosBasicoService.Insertar(nuevoModelo);

                if (respuesta)
                {
                    return StatusCode(StatusCodes.Status200OK, new { message = "Datos básicos insertados exitosamente." });
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error al insertar los datos básicos." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error interno del servidor: " + ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarDatos(int id, [FromBody] VMDatosBasico model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest(new { message = "Los datos básicos son nulos." });
                }

                DatosBasico datosBasicoExistente = await _datosBasicoService.Obtener(id);

                if (datosBasicoExistente == null)
                {
                    return NotFound(new { message = "No se encontraron datos básicos con el ID especificado." });
                }

                datosBasicoExistente.IdDatos = model.IdDatos;
                datosBasicoExistente.IdPerfil = model.IdPerfil;
                datosBasicoExistente.IdUsuarios = model.IdUsuarios;
                datosBasicoExistente.Nombres = model.Nombres;
                datosBasicoExistente.Apellidos = model.Apellidos;
                datosBasicoExistente.Idnacional = model.Idnacional;
                datosBasicoExistente.Direccion = model.Direccion;
                datosBasicoExistente.Celular = model.Celular;
                datosBasicoExistente.TelfLocal = model.TelfLocal;
                datosBasicoExistente.Referidos = model.Referidos;
                datosBasicoExistente.Calificacion = model.Calificacion;

                bool respuesta = await _datosBasicoService.Actualizar(datosBasicoExistente);

                if (respuesta)
                {
                    return StatusCode(StatusCodes.Status200OK, new { message = "Datos básicos actualizados exitosamente." });
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error al actualizar los datos básicos." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error interno del servidor: " + ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarDatos(int id)
        {
            try
            {
                var datosBasicoExistente = await _datosBasicoService.Obtener(id);

                if (datosBasicoExistente == null)
                {
                    return NotFound(new { message = "No se encontraron datos básicos con el ID especificado." });
                }

                bool respuesta = await _datosBasicoService.Eliminar(id);

                if (respuesta)
                {
                    return StatusCode(StatusCodes.Status200OK, new { message = "Datos básicos eliminados exitosamente." });
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error al eliminar los datos básicos." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error interno del servidor: " + ex.Message });
            }
        }
    }
}
