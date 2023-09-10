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
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet]
        public async Task<IActionResult> ListarCategorias()
        {
            try
            {
                IQueryable<VMCategoria> queryCategorias = await _categoriaService.ObtenerTodos();

                List<VMCategoria> Lista = queryCategorias
                    .Select(c => new VMCategoria()
                    {
                        IdCategoria = c.IdCategoria,
                        Categoria1 = c.Categoria1
                    }).ToList();

                return Ok(Lista);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error interno del servidor: " + ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerCategoria(int id)
        {
            try
            {
                var categoria = await _categoriaService.Obtener(id);

                if (categoria == null)
                {
                    return NotFound(new { message = "No se encontró ninguna categoría con el ID especificado." });
                }

                var vmCategoria = new VMCategoria()
                {
                    IdCategoria = categoria.IdCategoria,
                    Categoria1 = categoria.Categoria1
                };

                return Ok(vmCategoria);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error interno del servidor: " + ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertarCategoria([FromBody] VMCategoria model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest(new { message = "Los datos de la categoría son nulos." });
                }

                var nuevaCategoria = new VMCategoria()
                {
                    Categoria1 = model.Categoria1
                };

                bool respuesta = await _categoriaService.Insertar(nuevaCategoria);

                if (respuesta)
                {
                    return Ok(new { message = "Categoría insertada exitosamente." });
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error al insertar la categoría." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error interno del servidor: " + ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarCategoria(int id, [FromBody] VMCategoria model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest(new { message = "Los datos de la categoría son nulos." });
                }

                var categoriaExistente = await _categoriaService.Obtener(id);

                if (categoriaExistente == null)
                {
                    return NotFound(new { message = "No se encontró ninguna categoría con el ID especificado." });
                }

                categoriaExistente.Categoria1 = model.Categoria1;

                bool respuesta = await _categoriaService.Actualizar(categoriaExistente);

                if (respuesta)
                {
                    return Ok(new { message = "Categoría actualizada exitosamente." });
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error al actualizar la categoría." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error interno del servidor: " + ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarCategoria(int id)
        {
            try
            {
                var categoriaExistente = await _categoriaService.Obtener(id);

                if (categoriaExistente == null)
                {
                    return NotFound(new { message = "No se encontró ninguna categoría con el ID especificado." });
                }

                bool respuesta = await _categoriaService.Eliminar(id);

                if (respuesta)
                {
                    return Ok(new { message = "Categoría eliminada exitosamente." });
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error al eliminar la categoría." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error interno del servidor: " + ex.Message });
            }
        }
    }
}
