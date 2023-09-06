using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API_Services.DAL;
using API_Services.DAL.DataContext;
using API_Services.Models;

namespace API_Services.DAL.Repository
{
    public class PerfilNegocioRepository : IGenericRepository<PerfilNegocio>
    {
        private readonly AppserviceContext _dbcontext;
        
        public PerfilNegocioRepository(AppserviceContext dbcontext)
        {

            _dbcontext = dbcontext; 

        }

        public async Task<bool> Actualizar(PerfilNegocio modelo)
        {
            _dbcontext.PerfilNegocios.Update(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            PerfilNegocio modelo = _dbcontext.PerfilNegocios.First(c => c.IdPerfil == id);
            _dbcontext.PerfilNegocios.Remove(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Insertar(PerfilNegocio modelo)
        {
            _dbcontext.PerfilNegocios.Add(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<PerfilNegocio> Obtener(int id)
        {
            return await _dbcontext.PerfilNegocios.FindAsync(id);
        }

        public async Task<IQueryable<PerfilNegocio>> ObtenerTodos()
        {
            IQueryable<PerfilNegocio> queryPerfilSQL = _dbcontext.PerfilNegocios;
            return queryPerfilSQL;
        }
    }
}
