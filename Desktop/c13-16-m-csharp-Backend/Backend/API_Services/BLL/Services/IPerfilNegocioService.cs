using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API_Services.Models;

namespace API_Services.BLL.Services
{
    public interface IPerfilNegocioService
    {
        Task<bool> CrearPerfilNegocio(PerfilNegocio modelo); // Para crear un perfil de negocio
        Task<bool> ActualizarPerfilNegocio(PerfilNegocio modelo); // Para actualizar un perfil de negocio
        Task<bool> EliminarPerfilNegocio(int id); // Para eliminar un perfil de negocio
        Task<IQueryable<PerfilNegocio>> VerPerfilesNegocios(); // Para ver la lista de perfiles de negocios
        Task<PerfilNegocio> DetallesPerfilNegocio(int id); // Para obtener detalles de un perfil de negocio
    }
}
