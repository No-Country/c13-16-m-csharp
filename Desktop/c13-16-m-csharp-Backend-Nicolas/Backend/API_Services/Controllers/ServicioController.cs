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

            return StatusCode(StatusCodes.Status200OK, Lista);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerServicio(int id)
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

            return StatusCode(StatusCodes.Status200OK, vmServicio);
        }

        [HttpPost]
        public async Task<IActionResult> InsertarServicio([FromBody] VMServicio model)
        {
            bool respuesta = await _servicioService.Insertar(model);

            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarServicio(int id, [FromBody] VMServicio model)
        {
            var servicioExistente = await _servicioService.Obtener(id);

            if (servicioExistente == null)
            {
                return NotFound(new { message = "No se encontró ningún servicio con el ID especificado." });
            }

            servicioExistente.IdPerfil = model.IdPerfil;
            servicioExistente.IdCategoria = model.IdCategoria;
            servicioExistente.Servicio1 = model.Servicio1;
            servicioExistente.Precio = model.Precio;
            servicioExistente.Costo = model.Costo;

            bool respuesta = await _servicioService.Actualizar(model);

            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarServicio(int id)
        {
            bool respuesta = await _servicioService.Eliminar(id);

            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });
        }
    }
}
