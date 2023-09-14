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
    public class PedidoDetalleController : ControllerBase
    {
        private readonly IPedidoDetalleService _pedidoDetalleService;

        public PedidoDetalleController(IPedidoDetalleService pedidoDetalleService)
        {
            _pedidoDetalleService = pedidoDetalleService;
        }

        [HttpGet]
        public async Task<IActionResult> ListarDetallesPedido()
        {
            try
            {
                IQueryable<Models.PedidoDetalle> queryDetallesPedido = await _pedidoDetalleService.ObtenerTodos();

                List<VMPedidoDetalle> Lista = queryDetallesPedido
                    .Select(pd => new VMPedidoDetalle()
                    {
                        Renglon = pd.Renglon,
                        IdPedidoDetalle = pd.IdPedidoDetalle,
                        IdPedido = pd.IdPedido,
                        IdServicios = pd.IdServicios,
                        Cantidad = pd.Cantidad,
                        Precio = pd.Precio,
                        TotalRenglon = pd.TotalRenglon,
                        Comentario = pd.Comentario
                    }).ToList();

                return Ok(Lista);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error interno del servidor: " + ex.Message });
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerDetallePedido(int id)
        {
            try
            {
                var detallePedido = await _pedidoDetalleService.Obtener(id);

                if (detallePedido == null)
                {
                    return NotFound(new { message = "No se encontró ningún detalle de pedido con el ID especificado." });
                }

                var vmDetallePedido = new VMPedidoDetalle()
                {
                    Renglon = detallePedido.Renglon,
                    IdPedidoDetalle = detallePedido.IdPedidoDetalle,
                    IdPedido = detallePedido.IdPedido,
                    IdServicios = detallePedido.IdServicios,
                    Cantidad = detallePedido.Cantidad,
                    Precio = detallePedido.Precio,
                    TotalRenglon = detallePedido.TotalRenglon,
                    Comentario = detallePedido.Comentario
                };

                return Ok(vmDetallePedido);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error interno del servidor: " + ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertarDetallePedido([FromBody] VMPedidoDetalle model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest(new { message = "Los datos del detalle de pedido son nulos." });
                }

                // Crear un objeto PedidoDetalle a partir de VMPedidoDetalle
                var nuevoDetallePedido = new PedidoDetalle()
                {
                    IdPedido = model.IdPedido,
                    IdServicios = model.IdServicios,
                    Cantidad = model.Cantidad,
                    Precio = model.Precio,
                    TotalRenglon = model.TotalRenglon,
                    Comentario = model.Comentario
                };

                bool respuesta = await _pedidoDetalleService.Insertar(nuevoDetallePedido);

                if (respuesta)
                {
                    return Ok(new { message = "Detalle de pedido insertado exitosamente." });
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error al insertar el detalle de pedido." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error interno del servidor: " + ex.Message });
            }
        }


    }
}
