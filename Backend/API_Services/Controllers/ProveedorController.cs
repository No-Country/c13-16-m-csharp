using API_Services.BLL.Service;
using API_Services.Models.ViewModels;
using API_Services.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedorController : ControllerBase
    {
        private readonly IProveedoreService _ProveerService;

        public ProveedorController(IProveedoreService ProveerService)
        {
            _ProveerService = ProveerService;
        }
        
        [HttpGet]
        public async Task<IActionResult>Listarproveedor() 
        {
            IQueryable<Proveedore> queryProveedorSQL = await _ProveerService.ObtenerTodos();

            List<VMProveedore> Lista = queryProveedorSQL
                                .Select(c => new VMProveedore()
                                {
                                    IdProveedores = c.IdProveedores,
                                    IdDatos = c.IdDatos,
                                    Saldos = c.Saldos
                                    

                                }).ToList();
            return StatusCode(StatusCodes.Status200OK, Lista);
        }

        [HttpPost]
        public async Task<IActionResult> InsertarProveedor([FromBody] VMProveedore model)
        {
            Proveedore NuevoModelo = new Proveedore()
            {
                IdDatos = model.IdDatos,
                Saldos = model.Saldos
            };

            bool respuesta = await _ProveerService.Insertar(NuevoModelo);


            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });

        }
        [HttpPut]
        public async Task<IActionResult> ActualizarProveedor([FromBody] VMProveedore model)
        {
            Proveedore NuevoModelo = new Proveedore()
            {
                IdProveedores= model.IdProveedores,
                IdDatos = model.IdDatos,
                Saldos = model.Saldos
            };

            bool respuesta = await _ProveerService.Actualizar(NuevoModelo);


            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });

        }
        [HttpDelete]
        public async Task<IActionResult> EliminarProveedor(int id)
        {

            bool respuesta = await _ProveerService.Eliminar(id);


            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });

        }

    }
}
