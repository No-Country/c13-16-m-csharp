using API_Services.BLL.Service;
using API_Services.Models.ViewModels;
using API_Services.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace API_Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistorialProveedorController : ControllerBase
    {
        private readonly IHistorialProveedoreService _HistorialProveedorServi;

        public HistorialProveedorController(IHistorialProveedoreService HistorialProveedorServi)
        {
            _HistorialProveedorServi = HistorialProveedorServi;

        }
        [HttpGet]
        public async Task<IActionResult> ListarHistorialProveedor()
        {
            IQueryable<HistorialProveedore> queryHisproveeSQL = await _HistorialProveedorServi.ObtenerTodos();

            List<VMHistorialProveedore> Lista = queryHisproveeSQL
                                .Select(c => new VMHistorialProveedore()
                                {
                                    IdHistorialProveedor = c.IdHistorialProveedor,
                                    Renglon = c.Renglon,
                                    IdProveedores = c.IdProveedores,
                                    IdPedido = c.IdPedido,
                                    Monto = c.Monto,
                                    Saldo = c.Saldo,
                                    Fecha = c.Fecha.Value.ToString("dd/MM/yyyy")
        

                                }).ToList();
            return StatusCode(StatusCodes.Status200OK, Lista);

        }

        [HttpPost]
        public async Task<IActionResult> InsertarHistoriaProveedor([FromBody] VMHistorialProveedore model)
        {
            HistorialProveedore NuevoModelo = new HistorialProveedore()
            {
                
                Renglon = model.Renglon,
                IdProveedores = model.IdProveedores,
                IdPedido =model.IdPedido,
                Monto = model.Monto,
                Saldo = model.Saldo,
                Fecha = DateTime.ParseExact(model.Fecha,"dd/MM/yyyy", CultureInfo.CreateSpecificCulture("ve-ZA"))
            };

            bool respuesta = await _HistorialProveedorServi.Insertar(NuevoModelo);


            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });

        }
        [HttpPut]
        public async Task<IActionResult> ActualizarHistoriaProveedor([FromBody] VMHistorialProveedore model)
        {
            HistorialProveedore NuevoModelo = new HistorialProveedore()
            {
                IdHistorialProveedor = model.IdHistorialProveedor,
                Renglon = model.Renglon,
                IdProveedores = model.IdProveedores,
                IdPedido = model.IdPedido,
                Monto = model.Monto,
                Saldo = model.Saldo,
                Fecha = DateTime.ParseExact(model.Fecha, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("ve-ZA"))
            };

            bool respuesta = await _HistorialProveedorServi.Actualizar(NuevoModelo);


            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });

        }
        [HttpDelete]
        public async Task<IActionResult> EliminarHistoriaProveedor(int id)
        {
        

            bool respuesta = await _HistorialProveedorServi.Eliminar(id);


            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });

        }

    }
}
