using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API_Services.DAL;
using API_Services.DAL.DataContext;
using API_Services.Models;

namespace API_Services.DAL.Repository
{
    public class ProveedoreRepository: IGenericRepository<Proveedore>
    {
        private readonly AppserviceContext _dbcontext;

        public ProveedoreRepository(AppserviceContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<bool> Actualizar(Proveedore modelo)
        {
            _dbcontext.Proveedores.Update(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            Proveedore modelo = _dbcontext.Proveedores.First(c => c.IdProveedores == id);
            _dbcontext.Proveedores.Remove(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Insertar(Proveedore modelo)
        {
            _dbcontext.Proveedores.Add(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<Proveedore> Obtener(int id)
        {
            return await _dbcontext.Proveedores.FindAsync(id);
        }

        public async Task<IQueryable<Proveedore>> ObtenerTodos()
        {
            IQueryable<Proveedore> queryProveedorSQL = _dbcontext.Proveedores;
            return queryProveedorSQL;
        }
    }
}
