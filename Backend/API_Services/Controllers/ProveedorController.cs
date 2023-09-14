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
    public class ProveedorController : ControllerBase
    {
        private readonly IProveedoreService _proveedorService;

        public ProveedorController(IProveedoreService proveedorService)
        {
            _proveedorService = proveedorService;
        }

        [HttpGet]
        public async Task<IActionResult> ListarProveedor()
        {
            try
            {
                IQueryable<Proveedore> queryProveedorSQL = await _proveedorService.ObtenerTodos();

                List<VMProveedore> Lista = queryProveedorSQL
                    .Select(c => new VMProveedore()
                    {
                        IdProveedores = c.IdProveedores,
                        IdDatos = c.IdDatos,
                        Saldos = c.Saldos
                    }).ToList();

                return StatusCode(StatusCodes.Status200OK, Lista);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error interno del servidor: " + ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertarProveedor([FromBody] VMProveedore model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest(new { message = "Los datos del proveedor son nulos." });
                }

                Proveedore nuevoProveedor = new Proveedore()
                {
                    IdDatos = model.IdDatos, // Asignación directa, asumiendo que IdDatos es un entero
                    Saldos = model.Saldos
                };

                bool respuesta = await _proveedorService.Insertar(nuevoProveedor);

                if (respuesta)
                {
                    return StatusCode(StatusCodes.Status200OK, new { message = "Proveedor insertado exitosamente." });
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error al insertar el proveedor." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error interno del servidor: " + ex.Message });
            }
        }




        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarProveedor(int id, [FromBody] VMProveedore model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest(new { message = "Los datos del proveedor son nulos." });
                }

                var proveedorExistente = await _proveedorService.Obtener(id);

                if (proveedorExistente == null)
                {
                    return NotFound(new { message = "No se encontró ningún proveedor con el ID especificado." });
                }

                proveedorExistente.IdDatos = model.IdDatos; // Asignación directa, asumiendo que IdDatos es un entero
                proveedorExistente.Saldos = model.Saldos;

                bool respuesta = await _proveedorService.Actualizar(proveedorExistente);

                if (respuesta)
                {
                    return StatusCode(StatusCodes.Status200OK, new { message = "Proveedor actualizado exitosamente." });
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error al actualizar el proveedor." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error interno del servidor: " + ex.Message });
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarProveedor(int id)
        {
            try
            {
                var proveedorExistente = await _proveedorService.Obtener(id);

                if (proveedorExistente == null)
                {
                    return NotFound(new { message = "No se encontró ningún proveedor con el ID especificado." });
                }

                bool respuesta = await _proveedorService.Eliminar(id);

                if (respuesta)
                {
                    return StatusCode(StatusCodes.Status200OK, new { message = "Proveedor eliminado exitosamente." });
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error al eliminar el proveedor." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error interno del servidor: " + ex.Message });
            }
        }
    }
}
