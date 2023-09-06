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
    public class MonedaRepository : IGenericRpository<Monedum>
    {
        private readonly AppserviceContext _dbcontext;

        public MonedaRepository(AppserviceContext dbcontext)
        {
            _dbcontext= dbcontext;
        }

        public async Task<bool> Actualizar(Monedum modelo)
        {
            _dbcontext.Moneda.Update(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Insertar(Monedum modelo)
        {
            throw new NotImplementedException();
        }

        public async Task<IQueryable<Monedum>> ObtenerTodos()
        {
            throw new NotImplementedException();
        }

        public async Task<Monedum> Obtnener(int id)
        {
            throw new NotImplementedException();
        }
    }
}
