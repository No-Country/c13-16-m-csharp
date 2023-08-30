using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API_Services.Models;

namespace API_Services.BLL.Services
{
    public interface IPedidos
    {
        Task<bool> Insertar(Pedido modelo, PedidoDetalle detalle_modelo);
        Task<bool> Actualizar(Pedido modelo, PedidoDetalle detalle_modelo);
        Task<bool> Eliminar(int id);
        Task<Pedido> Obtnener(int id);
        Task<IQueryable<Pedido>> ObtenerTodos();
    }
}
