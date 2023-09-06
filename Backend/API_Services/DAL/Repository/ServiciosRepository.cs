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
    public class ServiciosRepository : IGenericRpository<Servicio>
    {
        private readonly AppserviceContext _dbcontext;
        public ServiciosRepository(AppserviceContext dbcontext)
        {
            _dbcontext=dbcontext;
        }
        public async Task<bool> Actualizar(Servicio modelo)
        {
            _dbcontext.Servicios.Update(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Insertar(Servicio modelo)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<Servicio>> ObtenerTodos()
        {
            throw new NotImplementedException();
        }

        public Task<Servicio> Obtnener(int id)
        {
            throw new NotImplementedException();
        }
    }
}
