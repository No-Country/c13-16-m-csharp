using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API_Services.Models;

namespace API_Services.BLL.Service
{
    public interface IPerfilNegocioService
    {
        Task<bool> Insertar(PerfilNegocio modelo);

        Task<bool> Actualizar(PerfilNegocio modelo);

        Task<bool> Eliminar(int id);

        Task<PerfilNegocio> Obtnener(int id);

        Task<IQueryable<PerfilNegocio>> ObtenerTodos();

        Task<PerfilNegocio> Obtenerxnombre(string nombre);
    }
}
