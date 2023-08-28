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
    public class RolRepository : IGenericRpository<Rol>
    {
        private readonly AppserviceContext _dbcontext;
        public RolRepository(AppserviceContext dbcontext)
        {

            _dbcontext = dbcontext;

        }
        public async Task<bool> Actualizar(Rol modelo)
        {
            _dbcontext.Rols.Update(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            Rol modelo = _dbcontext.Rols.First(c => c.IdRol == id);
            _dbcontext.Rols.Remove(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Insertar(Rol modelo)
        {
            _dbcontext.Rols.Add(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<IQueryable<Rol>> ObtenerTodos()
        {
            IQueryable<Rol> queryRolSQL = _dbcontext.Rols;
            return queryRolSQL;
        }

        public async Task<Rol> Obtnener(int id)
        {
            return await _dbcontext.Rols.FindAsync(id);
        }
    }
}
