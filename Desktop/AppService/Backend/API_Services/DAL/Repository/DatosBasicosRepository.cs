using API_Services.DAL.DataContext;
using API_Services.DAL.Repository;
using API_Services.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace API_Services.DAL.Repository
{
    public class DatosBasicosRepository : IGenericRepository<DatosBasico> 
    {
        private readonly AppserviceContext _dbcontext;

        public DatosBasicosRepository(AppserviceContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<bool> Insertar(DatosBasico entity)
        {
            _dbcontext.DatosBasicos.Add(entity);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Actualizar(DatosBasico entity)
        {
            _dbcontext.DatosBasicos.Update(entity);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var datosBasicos = await _dbcontext.DatosBasicos.FindAsync(id);
            if (datosBasicos != null)
            {
                _dbcontext.DatosBasicos.Remove(datosBasicos);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<DatosBasico> Obtener(int id) 
        {
            return await _dbcontext.DatosBasicos.FirstOrDefaultAsync(d => d.IdDatos == id);
        }

        public async Task<IQueryable<DatosBasico>> ObtenerTodos()
        {
            return _dbcontext.DatosBasicos;
        }
    }
}
