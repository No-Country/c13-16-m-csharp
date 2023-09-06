using API_Services.BLL.Service;
using API_Services.Models.ViewModels;
using API_Services.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatosBasicoController : ControllerBase
    {
        private readonly IDatosBasicoService _DatosService;

        public DatosBasicoController(IDatosBasicoService DatosService)
        {
            _DatosService= DatosService;
        }

        [HttpGet]
        public async Task<IActionResult> ListarDatosBasicos()
        {
            IQueryable<DatosBasico> queryDatosSQL = await _DatosService.ObtenerTodos();

            List<VMDatosBasico> Lista = queryDatosSQL
                                .Select(c => new VMDatosBasico()
                                {
                                    IdDatos = c.IdDatos,
                                    IdPerfil= c.IdPerfil,
                                    IdUsuarios= c.IdUsuarios,
                                    Nombres =    c.Nombres,
                                    Apellidos=   c.Apellidos,
                                    Idnacional=  c.Idnacional,
                                    Direccion =   c.Direccion,
                                    Celular = c.Celular,
                                    TelfLocal= c.TelfLocal,
                                    Referidos = c.Referidos,
                                    Calificacion = c.Calificacion


                                }).ToList();

            return StatusCode(StatusCodes.Status200OK, Lista);

        }

        [HttpPost]
        public async Task<IActionResult> InsertarDatos([FromBody] VMDatosBasico model)
        {
            DatosBasico NuevoModelo = new DatosBasico()
            {


                IdPerfil = model.IdPerfil,
                IdUsuarios = model.IdUsuarios,
                Nombres = model.Nombres,
                Apellidos = model.Apellidos,
                Idnacional = model.Idnacional,
                Direccion = model.Direccion,
                Celular = model.Celular,
                TelfLocal = model.TelfLocal,
                Referidos = model.Referidos,
                Calificacion = model.Calificacion
            };

            bool respuesta = await _DatosService.Insertar(NuevoModelo);


            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });

        }

        [HttpPut]
        public async Task<IActionResult> ActualizarDatos([FromBody] VMDatosBasico model)
        {
            DatosBasico NuevoModelo = new DatosBasico()
            {

                IdDatos = model.IdDatos,
                IdPerfil = model.IdPerfil,
                IdUsuarios = model.IdUsuarios,
                Nombres = model.Nombres,
                Apellidos = model.Apellidos,
                Idnacional = model.Idnacional,
                Direccion = model.Direccion,
                Celular = model.Celular,
                TelfLocal = model.TelfLocal,
                Referidos = model.Referidos,
                Calificacion = model.Calificacion
            };

            bool respuesta = await _DatosService.Actualizar(NuevoModelo);


            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });

        }

        [HttpPut]
        public async Task<IActionResult> EliminarDatos(int id)
        {
           

            bool respuesta = await _DatosService.Eliminar(id);


            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });

        }

    }
}
