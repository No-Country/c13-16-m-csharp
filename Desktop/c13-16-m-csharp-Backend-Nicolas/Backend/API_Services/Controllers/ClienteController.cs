using API_Services.BLL.Service;
using API_Services.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            IQueryable<VMCliente> queryClientes = await _clienteService.ObtenerTodos();

            List<VMCliente> Lista = queryClientes
                .Select(c => new VMCliente()
                {
                    IdCliente = c.IdCliente,
                    IdDatos = c.IdDatos,
                    Saldos = c.Saldos
                }).ToList();

            return StatusCode(StatusCodes.Status200OK, Lista);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerCliente(int id)
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

            return StatusCode(StatusCodes.Status200OK, vmCliente);
        }

        [HttpPost]
        public async Task<IActionResult> InsertarCliente([FromBody] VMCliente model)
        {
            var nuevoCliente = new VMCliente()
            {
                IdDatos = model.IdDatos,
                Saldos = model.Saldos
            };

            bool respuesta = await _clienteService.Insertar(nuevoCliente);

            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarCliente(int id, [FromBody] VMCliente model)
        {
            var clienteExistente = await _clienteService.Obtener(id);

            if (clienteExistente == null)
            {
                return NotFound(new { message = "No se encontró ningún cliente con el ID especificado." });
            }

            clienteExistente.IdDatos = model.IdDatos;
            clienteExistente.Saldos = model.Saldos;

            bool respuesta = await _clienteService.Actualizar(clienteExistente);

            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarCliente(int id)
        {
            var clienteExistente = await _clienteService.Obtener(id);

            if (clienteExistente == null)
            {
                return NotFound(new { message = "No se encontró ningún cliente con el ID especificado." });
            }

            bool respuesta = await _clienteService.Eliminar(id);

            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });
        }
    }
}
