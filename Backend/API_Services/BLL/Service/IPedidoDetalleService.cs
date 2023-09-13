using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API_Services.Models;

namespace API_Services.BLL.Service
{
    public interface IPedidoDetalleService
    {
        Task<bool> Insertar(PedidoDetalle modelo);

        Task<bool> Actualizar(PedidoDetalle modelo);

        Task<bool> Eliminar(int id);

        Task<PedidoDetalle> Obtnener(int id);

        Task<IQueryable<PedidoDetalle>> ObtenerTodos();

        Task<PedidoDetalle> Obtenerxnombre(string nombre);
    }
}
