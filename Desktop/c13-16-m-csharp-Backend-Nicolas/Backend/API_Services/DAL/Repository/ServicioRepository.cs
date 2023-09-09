using System;
using System.Linq;
using System.Threading.Tasks;
using API_Services.DAL.DataContext;
using API_Services.DAL.Repository;
using API_Services.Models;

namespace API_Services.DAL.Repository
{
    public class ServicioRepository : IGenericRepository<Servicio>
    {
        private readonly AppserviceContext _dbContext;

        public ServicioRepository(AppserviceContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Actualizar(Servicio modelo)
        {
            _dbContext.Servicios.Update(modelo);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            Servicio modelo = _dbContext.Servicios.First(s => s.IdServicio == id);
            _dbContext.Servicios.Remove(modelo);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Insertar(Servicio modelo)
        {
            _dbContext.Servicios.Add(modelo);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Servicio> Obtener(int id)
        {
            return await _dbContext.Servicios.FindAsync(id);
        }

        public async Task<IQueryable<Servicio>> ObtenerTodos()
        {
            IQueryable<Servicio> queryServicioSQL = _dbContext.Servicios;
            return queryServicioSQL;
        }
    }
}
