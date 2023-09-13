using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API_Services.Models;

namespace API_Services.BLL.Service
{
    public interface IPedidoService
    {
        Task<bool> Insertar(Pedido modelo);

        Task<bool> Actualizar(Pedido modelo);

        Task<bool> Eliminar(int id);

        Task<Pedido> Obtnener(int id);

        Task<IQueryable<Pedido>> ObtenerTodos();

        Task<Pedido> Obtenerxnombre(string nombre);
    }
}
