using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API_Services.DAL;
using API_Services.DAL.DataContext;
using API_Services.DAL.Repository;
using API_Services.Models;

namespace API_Services.DAL.Repository
{
    public class TasaRepository : IGenericRpository<Tasa>
    {
        private readonly AppserviceContext _dbcontext;
        public TasaRepository(AppserviceContext dbcontext)
        {
                _dbcontext= dbcontext;
        }
        public async Task<bool> Actualizar(Tasa modelo)
        {
            _dbcontext.Tasas.Update(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;

        }

        public async Task<bool> Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Insertar(Tasa modelo)
        {
            throw new NotImplementedException();
        }

        public async Task<IQueryable<Tasa>> ObtenerTodos()
        {
            throw new NotImplementedException();
        }

        public async Task<Tasa> Obtnener(int id)
        {
            throw new NotImplementedException();
        }
    }
}
