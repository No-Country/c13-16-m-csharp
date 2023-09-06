using API_Services.BLL.Service;
using API_Services.Models.ViewModels;
using API_Services.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuariosService _UsuarioService;

        public UsuarioController(IUsuariosService UsuarioService)
        {
            _UsuarioService = UsuarioService;
        }

        [HttpGet]
        public async Task<IActionResult> ListarUsuarios()
        {
            IQueryable<Usuario> queryUsuarioSQL = await _UsuarioService.ObtenerTodos();

            List<VMUsuario> Lista = queryUsuarioSQL
                                .Select(c => new VMUsuario()
                                {
                                    IdUsuarios = c.IdUsuarios,
                                    
                                    NombreUsuario = c.NombreUsuario,

                                    Clave = c.Clave,

                                    Estado = c.Estado,

                                    Correo= c.Correo
                                    

                                }).ToList();

            return StatusCode(StatusCodes.Status200OK, Lista);

        }

        [HttpPost]
        public async Task<IActionResult> InsertarUsuario([FromBody] VMUsuario model)
        {
            Usuario NuevoModelo = new Usuario()
            {
               

                NombreUsuario = model.NombreUsuario,

                Clave = model.Clave,

                Estado = model.Estado,

                Correo = model.Correo
            };

            bool respuesta = await _UsuarioService.Insertar(NuevoModelo);


            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });

        }
        [HttpPut]
        public async Task<IActionResult> ActualizarUsuario([FromBody] VMUsuario model)
        {
            Usuario NuevoModelo = new Usuario()
            {
                IdUsuarios = model.IdUsuarios,

                NombreUsuario = model.NombreUsuario,

                Clave = model.Clave,

                Estado = model.Estado,

                Correo = model.Correo
            };

            bool respuesta = await _UsuarioService.Actualizar(NuevoModelo);


            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });

        }

        [HttpDelete]
        public async Task<IActionResult> EliminarUsuario(int id)
        {

            bool respuesta = await _UsuarioService.Eliminar(id);


            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });

        }

    }
}
