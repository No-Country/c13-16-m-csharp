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
    public class HistorialProveedoreRepository : IGenericRepository<HistorialProveedore>
    {
        private readonly AppserviceContext _dbcontext;
        public HistorialProveedoreRepository(AppserviceContext dbcontext)
        {

            _dbcontext = dbcontext;

        }
        public async Task<bool> Actualizar(HistorialProveedore modelo)
        {
            _dbcontext.HistorialProveedores.Update(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            HistorialProveedore modelo = _dbcontext.HistorialProveedores.First(c => c.IdPedido == id);
            _dbcontext.HistorialProveedores.Remove(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Insertar(HistorialProveedore modelo)
        {
            _dbcontext.HistorialProveedores.Add(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<HistorialProveedore> Obtener(int id)
        {
            return await _dbcontext.HistorialProveedores.FindAsync(id);
        }

        public async Task<IQueryable<HistorialProveedore>> ObtenerTodos()
        {
            IQueryable<HistorialProveedore> queryHistoriaProveSQL = _dbcontext.HistorialProveedores;
            return queryHistoriaProveSQL;
        }
    }
}
