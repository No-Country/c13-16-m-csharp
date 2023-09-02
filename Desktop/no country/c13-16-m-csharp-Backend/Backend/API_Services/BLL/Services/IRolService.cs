using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API_Services.Models;

namespace API_Services.BLL.Services
{
    public interface IRolService
    {
        Task<bool> Insertar(Rol modelo);
        Task<bool> Actualizar(Rol modelo);
        Task<bool> Eliminar(int id);
        Task<Rol> Obtnener(int id);
        Task<IQueryable<Rol>> ObtenerTodos();
        Task<Rol> Obtenerxnombre(string nombre);
    }
}
