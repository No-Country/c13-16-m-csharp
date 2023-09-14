using API_Services.BLL.Service;
using API_Services.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<IActionResult> ListarClientes()
        {
            try
            {
                IQueryable<VMCliente> queryClientes = await _clienteService.ObtenerTodos();

                List<VMCliente> Lista = queryClientes
                    .Select(c => new VMCliente()
                    {
                        IdCliente = c.IdCliente,
                        IdDatos = c.IdDatos,
                        Saldos = c.Saldos
                    }).ToList();

                return Ok(Lista);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error interno del servidor: " + ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerCliente(int id)
        {
            try
            {
                var cliente = await _clienteService.Obtener(id);

                if (cliente == null)
                {
                    return NotFound(new { message = "No se encontró ningún cliente con el ID especificado." });
                }

                var vmCliente = new VMCliente()
                {
                    IdCliente = cliente.IdCliente,
                    IdDatos = cliente.IdDatos,
                    Saldos = cliente.Saldos
                };

                return Ok(vmCliente);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error interno del servidor: " + ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertarCliente([FromBody] VMCliente model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest(new { message = "Los datos del cliente son nulos." });
                }

                if (string.IsNullOrEmpty(model.IdDatos))
                {
                    return BadRequest(new { message = "El ID de datos es obligatorio." });
                }

                var nuevoCliente = new VMCliente()
                {
                    IdDatos = model.IdDatos,
                    Saldos = model.Saldos
                };

                bool respuesta = await _clienteService.Insertar(nuevoCliente);

                if (respuesta)
                {
                    return Ok(new { message = "Cliente insertado exitosamente." });
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error al insertar el cliente." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error interno del servidor: " + ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarCliente(int id, [FromBody] VMCliente model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest(new { message = "Los datos del cliente son nulos." });
                }

                var clienteExistente = await _clienteService.Obtener(id);

                if (clienteExistente == null)
                {
                    return NotFound(new { message = "No se encontró ningún cliente con el ID especificado." });
                }

                if (string.IsNullOrEmpty(model.IdDatos))
                {
                    return BadRequest(new { message = "El ID de datos es obligatorio." });
                }

                clienteExistente.IdDatos = model.IdDatos;
                clienteExistente.Saldos = model.Saldos;

                bool respuesta = await _clienteService.Actualizar(clienteExistente);

                if (respuesta)
                {
                    return Ok(new { message = "Cliente actualizado exitosamente." });
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error al actualizar el cliente." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error interno del servidor: " + ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarCliente(int id)
        {
            try
            {
                var clienteExistente = await _clienteService.Obtener(id);

                if (clienteExistente == null)
                {
                    return NotFound(new { message = "No se encontró ningún cliente con el ID especificado." });
                }

                bool respuesta = await _clienteService.Eliminar(id);

                if (respuesta)
                {
                    return Ok(new { message = "Cliente eliminado exitosamente." });
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error al eliminar el cliente." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error interno del servidor: " + ex.Message });
            }
        }
    }
}
