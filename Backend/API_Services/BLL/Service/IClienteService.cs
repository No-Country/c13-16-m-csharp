using System;
using System.Linq;
using System.Threading.Tasks;
using API_Services.Models;
using API_Services.Models.ViewModels;

namespace API_Services.BLL.Service
{
    public interface IClienteService
    {
        Task<bool> Insertar(VMCliente modelo);
        Task<bool> Actualizar(VMCliente modelo);
        Task<bool> Eliminar(int id);
        Task<VMCliente> Obtener(int id);
        Task<IQueryable<VMCliente>> ObtenerTodos();
    }
}
