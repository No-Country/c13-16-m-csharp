using System;
using System.Linq;
using System.Threading.Tasks;
using API_Services.DAL.DataContext;
using API_Services.DAL.Repository;
using API_Services.Models;

namespace API_Services.DAL.Repository
{
    public class ClienteRepository : IGenericRepository<Cliente>
    {
        private readonly AppserviceContext _dbContext;

        public ClienteRepository(AppserviceContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Actualizar(Cliente modelo)
        {
            _dbContext.Clientes.Update(modelo);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            Cliente modelo = _dbContext.Clientes.First(c => c.IdCliente == id);
            _dbContext.Clientes.Remove(modelo);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Insertar(Cliente modelo)
        {
            _dbContext.Clientes.Add(modelo);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Cliente> Obtener(int id)
        {
            return await _dbContext.Clientes.FindAsync(id);
        }

        public async Task<IQueryable<Cliente>> ObtenerTodos()
        {
            IQueryable<Cliente> queryClienteSQL = _dbContext.Clientes;
            return queryClienteSQL;
        }
    }
}
