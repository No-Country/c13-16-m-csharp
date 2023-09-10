using API_Services.BLL.Service;
using API_Services.Models;
using API_Services.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly IRolService _rolService;

        public RolController(IRolService rolService)
        {
            _rolService = rolService;
        }

        [HttpGet]
        public async Task<IActionResult> ListarROL() 
        {
            IQueryable<Rol> queryRolSQL = await _rolService.ObtenerTodos();

            List<VMRol> Lista = queryRolSQL
                                .Select(c => new VMRol()
                                {

                                    IdRol = c.IdRol,
                                    Roles = c.Roles

                                }).ToList();
            return StatusCode(StatusCodes.Status200OK, Lista);

        }
        [HttpPost]
        public async Task<IActionResult> InsertarROL([FromBody] VMRol model)
        {
            Rol NuevoModelo = new Rol() 
            { 
                Roles = model.Roles
            };

            bool respuesta = await _rolService.Insertar(NuevoModelo);

            
            return StatusCode(StatusCodes.Status200OK, new { valor= respuesta} );

        }
        [HttpPut]
        public async Task<IActionResult> ActualizarROL([FromBody] VMRol model)
        {
            Rol NuevoModelo = new Rol()
            {
                IdRol= model.IdRol,
                Roles = model.Roles
            };

            bool respuesta = await _rolService.Actualizar(NuevoModelo);


            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });

        }
        [HttpDelete]
        public async Task<IActionResult> EliminarROL(int id)
        {
            

            bool respuesta = await _rolService.Eliminar(id);


            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });

        }
    }
}
