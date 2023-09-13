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
    public class HistorialClienteController : ControllerBase
    {
        private readonly IHistorialClienteService _HistorialClienteServi;
        
        public HistorialClienteController(IHistorialClienteService HistorialClienteServi)
        {
            _HistorialClienteServi = HistorialClienteServi;            
        }

        [HttpGet]
        public async Task<IActionResult> ListarHistorialCliente()
        {
            IQueryable<HistorialCliente> queryHisclienteSQL = await _HistorialClienteServi.ObtenerTodos();

            List<VMHistorialCliente> Lista = queryHisclienteSQL
                                .Select(c => new VMHistorialCliente()
                                {
                                    IdHistorial = c.IdHistorial,
                                    Renglon = c.Renglon,
                                    IdCliente = c.IdCliente,
                                    IdPedido = c.IdPedido,
                                    Monto = c.Monto,
                                    Saldo = c.Saldo,
                                    Fecha = c.Fecha.Value.ToString("dd/MM/yyyy")


                                }).ToList();
            return StatusCode(StatusCodes.Status200OK, Lista);

        }
        [HttpPost]
        public async Task<IActionResult> InsertarHistoriaCliente([FromBody] VMHistorialCliente model)
        {
            HistorialCliente NuevoModelo = new HistorialCliente()
            {

                Renglon = model.Renglon,
                IdCliente = model.IdCliente,
                IdPedido = model.IdPedido,
                Monto = model.Monto,
                Saldo = model.Saldo,
                Fecha = DateTime.ParseExact(model.Fecha, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("ve-ZA"))
            };

            bool respuesta = await _HistorialClienteServi.Insertar(NuevoModelo);


            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });

        }
        [HttpPut]
        public async Task<IActionResult> ActualizarHistoriaCliente([FromBody] VMHistorialCliente model)
        {
            HistorialCliente NuevoModelo = new HistorialCliente()
            {
                IdHistorial = model.IdHistorial,
                Renglon = model.Renglon,
                IdCliente = model.IdCliente,
                IdPedido = model.IdPedido,
                Monto = model.Monto,
                Saldo = model.Saldo,
                Fecha = DateTime.ParseExact(model.Fecha, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("ve-ZA"))
            };

            bool respuesta = await _HistorialClienteServi.Actualizar(NuevoModelo);


            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });

        }
        [HttpDelete]
        public async Task<IActionResult> EliminarHistoriaCliente(int id)
        {

            bool respuesta = await _HistorialClienteServi.Eliminar(id);


            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });

        }
    }
}


