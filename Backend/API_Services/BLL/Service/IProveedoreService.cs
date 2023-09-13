using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API_Services.Models;

namespace API_Services.BLL.Service
{
    public interface IProveedoreService
    {
        Task<bool> Insertar(Proveedore modelo);

        Task<bool> Actualizar(Proveedore modelo);

        Task<bool> Eliminar(int id);

        Task<Proveedore> Obtnener(int id);

        Task<IQueryable<Proveedore>> ObtenerTodos();

        Task<Proveedore> Obtenerxnombre(string nombre);
    }
}
