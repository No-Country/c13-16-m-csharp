using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Services.Models;
using API_Services.Models.ViewModels;

namespace API_Services.BLL.Service
{
    public interface IServicioService
    {
        Task<bool> Insertar(VMServicio modelo);
        Task<bool> Actualizar(VMServicio modelo);
        Task<bool> Eliminar(int id);
        Task<VMServicio> Obtener(int id);
        Task<IQueryable<VMServicio>> ObtenerTodos();
        Task<VMServicio> ObtenerPorNombreCategoria(string nombreCategoria);
    }
}
