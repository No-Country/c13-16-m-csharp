using System;
using System.Linq;
using System.Threading.Tasks;
using API_Services.Models.ViewModels;

namespace API_Services.BLL.Service
{
    public interface ICategoriaService
    {
        Task<bool> Insertar(VMCategoria modelo);
        Task<bool> Actualizar(VMCategoria modelo);
        Task<bool> Eliminar(int id);
        Task<VMCategoria> Obtener(int id);
        Task<IQueryable<VMCategoria>> ObtenerTodos();
    }
}
