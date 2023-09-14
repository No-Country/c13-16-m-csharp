using API_Services.BLL.Service;
using API_Services.Models;
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
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;

        public PedidoController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpGet]
        public async Task<IActionResult> ListarPedidos()
        {
            try
            {
                IQueryable<Pedido> queryPedidos = await _pedidoService.ObtenerTodos();

                List<VMPedido> Lista = queryPedidos
                    .Select(p => new VMPedido()
                    {
                        IdPedido = p.IdPedido,
                        IdCliente = p.IdCliente,
                        IdPerfil = p.IdPerfil,
                        FechaSolicitud = p.FechaSolicitud.ToString("yyyy-MM-dd"),
                        FechaAsignacion = p.FechaAsignacion.ToString("yyyy-MM-dd"),
                        IdMoneda = p.IdMoneda,
                        IdTasa = p.IdTasa,
                        IdProveedores = p.IdProveedores,
                        TotalServicios = p.TotalServicios,
                        Asignado = p.Asignado
                    }).ToList();

                return Ok(Lista);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error interno del servidor: " + ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPedido(int id)
        {
            try
            {
                var pedido = await _pedidoService.Obtener(id);

                if (pedido == null)
                {
                    return NotFound(new { message = "No se encontró ningún pedido con el ID especificado." });
                }

                var vmPedido = new VMPedido()
                {
                    IdPedido = pedido.IdPedido,
                    IdCliente = pedido.IdCliente,
                    IdPerfil = pedido.IdPerfil,
                    FechaSolicitud = pedido.FechaSolicitud.ToString("yyyy-MM-dd"),
                    FechaAsignacion = pedido.FechaAsignacion.ToString("yyyy-MM-dd"),
                    IdMoneda = pedido.IdMoneda,
                    IdTasa = pedido.IdTasa,
                    IdProveedores = pedido.IdProveedores,
                    TotalServicios = pedido.TotalServicios,
                    Asignado = pedido.Asignado
                };

                return Ok(vmPedido);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error interno del servidor: " + ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarPedido(int id, [FromBody] VMPedido model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest(new { message = "Los datos del pedido son nulos." });
                }

                var pedidoExistente = await _pedidoService.Obtener(id);

                if (pedidoExistente == null)
                {
                    return NotFound(new { message = "No se encontró ningún pedido con el ID especificado." });
                }

                pedidoExistente.IdCliente = model.IdCliente;
                pedidoExistente.IdPerfil = model.IdPerfil;

                if (!string.IsNullOrWhiteSpace(model.FechaSolicitud) && DateTime.TryParse(model.FechaSolicitud, out DateTime fechaSolicitud))
                {
                    pedidoExistente.FechaSolicitud = fechaSolicitud;
                }
                else
                {
                    return BadRequest(new { message = "La fecha de solicitud no es válida." });
                }

                if (!string.IsNullOrWhiteSpace(model.FechaAsignacion) && DateTime.TryParse(model.FechaAsignacion, out DateTime fechaAsignacion))
                {
                    pedidoExistente.FechaAsignacion = fechaAsignacion;
                }
                else
                {
                    return BadRequest(new { message = "La fecha de asignación no es válida." });
                }

                pedidoExistente.IdMoneda = model.IdMoneda;
                pedidoExistente.IdTasa = model.IdTasa;
                pedidoExistente.IdProveedores = model.IdProveedores;
                pedidoExistente.TotalServicios = model.TotalServicios;
                pedidoExistente.Asignado = model.Asignado;

                bool respuesta = await _pedidoService.Actualizar(pedidoExistente);

                if (respuesta)
                {
                    return Ok(new { message = "Pedido actualizado exitosamente." });
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error al actualizar el pedido." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error interno del servidor: " + ex.Message });
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarPedido(int id)
        {
            try
            {
                var pedidoExistente = await _pedidoService.Obtener(id);

                if (pedidoExistente == null)
                {
                    return NotFound(new { message = "No se encontró ningún pedido con el ID especificado." });
                }

                bool respuesta = await _pedidoService.Eliminar(id);

                if (respuesta)
                {
                    return Ok(new { message = "Pedido eliminado exitosamente." });
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error al eliminar el pedido." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error interno del servidor: " + ex.Message });
            }
        }
    }
}
