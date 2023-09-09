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
            IQueryable<VMCategoria> queryCategorias = await _categoriaService.ObtenerTodos();

            List<VMCategoria> Lista = queryCategorias
                .Select(c => new VMCategoria()
                {
                    IdCategoria = c.IdCategoria,
                    Categoria1 = c.Categoria1
                }).ToList();

            return StatusCode(StatusCodes.Status200OK, Lista);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerCategoria(int id)
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

            return StatusCode(StatusCodes.Status200OK, vmCategoria);
        }

        [HttpPost]
        public async Task<IActionResult> InsertarCategoria([FromBody] VMCategoria model)
        {
            var nuevaCategoria = new VMCategoria()
            {
                Categoria1 = model.Categoria1
            };

            bool respuesta = await _categoriaService.Insertar(nuevaCategoria);

            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarCategoria(int id, [FromBody] VMCategoria model)
        {
            var categoriaExistente = await _categoriaService.Obtener(id);

            if (categoriaExistente == null)
            {
                return NotFound(new { message = "No se encontró ninguna categoría con el ID especificado." });
            }

            categoriaExistente.Categoria1 = model.Categoria1;

            bool respuesta = await _categoriaService.Actualizar(categoriaExistente);

            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarCategoria(int id)
        {
            var categoriaExistente = await _categoriaService.Obtener(id);

            if (categoriaExistente == null)
            {
                return NotFound(new { message = "No se encontró ninguna categoría con el ID especificado." });
            }

            bool respuesta = await _categoriaService.Eliminar(id);

            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });
        }
    }
}
