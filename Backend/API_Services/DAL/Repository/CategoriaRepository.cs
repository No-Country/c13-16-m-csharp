using System;
using System.Linq;
using System.Threading.Tasks;
using API_Services.DAL.DataContext;
using API_Services.DAL.Repository;
using API_Services.Models;

namespace API_Services.DAL.Repository
{
    public class CategoriaRepository : IGenericRepository<Categoria>
    {
        private readonly AppserviceContext _dbContext;

        public CategoriaRepository(AppserviceContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Actualizar(Categoria modelo)
        {
            _dbContext.Categorias.Update(modelo);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            Categoria modelo = _dbContext.Categorias.First(c => c.IdCategoria == id);
            _dbContext.Categorias.Remove(modelo);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Insertar(Categoria modelo)
        {
            _dbContext.Categorias.Add(modelo);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Categoria> Obtener(int id)
        {
            return await _dbContext.Categorias.FindAsync(id);
        }

        public async Task<IQueryable<Categoria>> ObtenerTodos()
        {
            IQueryable<Categoria> queryCategoriaSQL = _dbContext.Categorias;
            return queryCategoriaSQL;
        }
    }
}
