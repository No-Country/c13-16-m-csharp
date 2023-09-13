using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API_Services.Models;

namespace API_Services.BLL.Service
{
    public interface IHistorialProveedoreService
    {
        Task<bool> Insertar(HistorialProveedore modelo);

        Task<bool> Actualizar(HistorialProveedore modelo);

        Task<bool> Eliminar(int id);

        Task<HistorialProveedore> Obtnener(int id);

        Task<IQueryable<HistorialProveedore>> ObtenerTodos();

        Task<HistorialProveedore> Obtenerxnombre(string nombre);

    }
}
