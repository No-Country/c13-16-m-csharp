using API_Services.BLL.Service;
using API_Services.Models.ViewModels;
using API_Services.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace API_Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistorialClienteController : ControllerBase
    {
        private readonly IHistorialClienteService _historialClienteService;

        public HistorialClienteController(IHistorialClienteService historialClienteService)
        {
            _historialClienteService = historialClienteService;
        }

        [HttpGet]
        public async Task<IActionResult> ListarHistorialCliente()
        {
            try
            {
                IQueryable<HistorialCliente> queryHistorialClienteSQL = await _historialClienteService.ObtenerTodos();

                List<VMHistorialCliente> Lista = queryHistorialClienteSQL
                    .Select(c => new VMHistorialCliente()
                    {
                        IdHistorial = c.IdHistorial,
                        Renglon = c.Renglon,
                        IdCliente = c.IdCliente,
                        IdPedido = c.IdPedido,
                        Monto = c.Monto,
                        Saldo = c.Saldo,
                        Fecha = c.Fecha.Value.ToString("dd/MM/yyyy")
                    }).ToList();

                return StatusCode(StatusCodes.Status200OK, Lista);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error interno del servidor: " + ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertarHistoriaCliente([FromBody] VMHistorialCliente model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest(new { message = "Los datos del historial del cliente son nulos." });
                }

                if (model.Fecha == null)
                {
                    return BadRequest(new { message = "La fecha es obligatoria." });
                }

                HistorialCliente nuevoHistorialCliente = new HistorialCliente()
                {
                    Renglon = model.Renglon,
                    IdCliente = model.IdCliente,
                    IdPedido = model.IdPedido,
                    Monto = model.Monto,
                    Saldo = model.Saldo,
                    Fecha = DateTime.ParseExact(model.Fecha, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("ve-ZA"))
                };

                bool respuesta = await _historialClienteService.Insertar(nuevoHistorialCliente);

                if (respuesta)
                {
                    return StatusCode(StatusCodes.Status200OK, new { message = "Historial del cliente insertado exitosamente." });
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error al insertar el historial del cliente." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error interno del servidor: " + ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarHistoriaCliente(int id, [FromBody] VMHistorialCliente model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest(new { message = "Los datos del historial del cliente son nulos." });
                }

                if (model.Fecha == null)
                {
                    return BadRequest(new { message = "La fecha es obligatoria." });
                }

                HistorialCliente historialClienteExistente = await _historialClienteService.Obtener(id);

                if (historialClienteExistente == null)
                {
                    return NotFound(new { message = "No se encontró ningún historial del cliente con el ID especificado." });
                }

                historialClienteExistente.Renglon = model.Renglon;
                historialClienteExistente.IdCliente = model.IdCliente;
                historialClienteExistente.IdPedido = model.IdPedido;
                historialClienteExistente.Monto = model.Monto;
                historialClienteExistente.Saldo = model.Saldo;
                historialClienteExistente.Fecha = DateTime.ParseExact(model.Fecha, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("ve-ZA"));

                bool respuesta = await _historialClienteService.Actualizar(historialClienteExistente);

                if (respuesta)
                {
                    return StatusCode(StatusCodes.Status200OK, new { message = "Historial del cliente actualizado exitosamente." });
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error al actualizar el historial del cliente." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error interno del servidor: " + ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarHistoriaCliente(int id)
        {
            try
            {
                var historialClienteExistente = await _historialClienteService.Obtener(id);

                if (historialClienteExistente == null)
                {
                    return NotFound(new { message = "No se encontró ningún historial del cliente con el ID especificado." });
                }

                bool respuesta = await _historialClienteService.Eliminar(id);

                if (respuesta)
                {
                    return StatusCode(StatusCodes.Status200OK, new { message = "Historial del cliente eliminado exitosamente." });
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error al eliminar el historial del cliente." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error interno del servidor: " + ex.Message });
            }
        }
    }
}
