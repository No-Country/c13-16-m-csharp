using API_Services.BLL.Service;
using API_Services.Models.ViewModels;
using API_Services.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilNegocioController : ControllerBase
    {
        private readonly IPerfilNegocioService _PerfilService;
        
        public PerfilNegocioController(IPerfilNegocioService PerfilService)
        {
            _PerfilService= PerfilService;
        }

        [HttpGet]
        public async Task<IActionResult> ListarPerfil()
        {
            IQueryable<PerfilNegocio> queryPerfilSQL = await _PerfilService.ObtenerTodos();

            List<VMPerfilNegocio> Lista = queryPerfilSQL
                                .Select(c => new VMPerfilNegocio()
                                {
                                    IdPerfil = c.IdPerfil,
                                    NombrePerfil = c.NombrePerfil

                                }).ToList();
            return StatusCode(StatusCodes.Status200OK, Lista);

        }
        [HttpPost]
        public async Task<IActionResult> InsertarPerfil([FromBody] VMPerfilNegocio model)
        {
            PerfilNegocio NuevoModelo = new PerfilNegocio()
            {
                NombrePerfil = model.NombrePerfil
            };

            bool respuesta = await _PerfilService.Insertar(NuevoModelo);


            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });

        }
        [HttpPut]
        public async Task<IActionResult> ActualizarPerfil([FromBody] VMPerfilNegocio model)
        {
            PerfilNegocio NuevoModelo = new PerfilNegocio()
            {
                IdPerfil = model.IdPerfil,
                NombrePerfil = model.NombrePerfil
            };

            bool respuesta = await _PerfilService.Actualizar(NuevoModelo);


            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });

        }

        [HttpPut]
        public async Task<IActionResult> EliminarPerfil(int id)
        {

            bool respuesta = await _PerfilService.Eliminar(id);


            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });

        }

    }
}
