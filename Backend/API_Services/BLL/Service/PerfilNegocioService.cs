using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API_Services.Models;
using API_Services.DAL;
using API_Services.DAL.Repository;


namespace API_Services.BLL.Service
{
    public class PerfilNegocioService : IPerfilNegocioService
    {
        private readonly IGenericRepository<PerfilNegocio> _PerfilRepo;

        public PerfilNegocioService(IGenericRepository<PerfilNegocio> PerfilRepo)
        {

            _PerfilRepo=PerfilRepo;

        }

        public async Task<bool> Actualizar(PerfilNegocio modelo)
        {
            return await _PerfilRepo.Actualizar(modelo);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await _PerfilRepo.Eliminar(id);
        }

        public async Task<bool> Insertar(PerfilNegocio modelo)
        {
            return await _PerfilRepo.Insertar(modelo);
        }

        public async Task<IQueryable<PerfilNegocio>> ObtenerTodos()
        {
            return await _PerfilRepo.ObtenerTodos();    
        }

        public async Task<PerfilNegocio> Obtenerxnombre(string nombre)
        {
            IQueryable<PerfilNegocio> querySQL = await _PerfilRepo.ObtenerTodos();
            PerfilNegocio roles = querySQL.Where(c => c.NombrePerfil == nombre).FirstOrDefault();
            return roles;
        }

        public async Task<PerfilNegocio> Obtnener(int id)
        {
            return await _PerfilRepo.Obtener(id);
        }
    }
}
