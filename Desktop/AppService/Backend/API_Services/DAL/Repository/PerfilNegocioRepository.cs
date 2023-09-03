using API_Services.DAL.DataContext;
using API_Services.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;


namespace API_Services.DAL.Repository
{
    public class PerfilNegocioRepository : IGenericRepository<PerfilNegocio>
    {
        private readonly AppserviceContext _dbcontext;

        public PerfilNegocioRepository(AppserviceContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<bool> Insertar(PerfilNegocio entity)
        {
            _dbcontext.PerfilNegocios.Add(entity);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Actualizar(PerfilNegocio entity)
        {
            _dbcontext.PerfilNegocios.Update(entity);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var perfilNegocio = await _dbcontext.PerfilNegocios.FindAsync(id);
            if (perfilNegocio != null)
            {
                _dbcontext.PerfilNegocios.Remove(perfilNegocio);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<PerfilNegocio> Obtener(int id)
        {
            return await _dbcontext.PerfilNegocios.FirstOrDefaultAsync(p => p.IdPerfil == id);
        }

        public async Task<IQueryable<PerfilNegocio>> ObtenerTodos()
        {
            return _dbcontext.PerfilNegocios;
        }
    }
}
