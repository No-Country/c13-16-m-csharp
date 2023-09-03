using API_Services.DAL.DataContext;
using API_Services.DAL.Repository;
using API_Services.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace API_Services.DAL.Repository
{
    public class CategoriaRepository : IGenericRepository<Categoria> 
    {
        private readonly AppserviceContext _dbcontext;

        public CategoriaRepository(AppserviceContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<bool> Insertar(Categoria entity)
        {
            _dbcontext.Categorias.Add(entity);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Actualizar(Categoria entity)
        {
            _dbcontext.Categorias.Update(entity);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var categoria = await _dbcontext.Categorias.FindAsync(id);
            if (categoria != null)
            {
                _dbcontext.Categorias.Remove(categoria);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Categoria> Obtener(int id) 
        {
            return await _dbcontext.Categorias.FirstOrDefaultAsync(c => c.IdCategoria == id);
        }

        public async Task<IQueryable<Categoria>> ObtenerTodos()
        {
            return _dbcontext.Categorias;
        }
    }
}
