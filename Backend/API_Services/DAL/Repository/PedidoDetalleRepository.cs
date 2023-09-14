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
    public class PedidoDetalleRepository : IGenericRepository<PedidoDetalle>
    {
        private readonly AppserviceContext _dbcontext;

        public PedidoDetalleRepository(AppserviceContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        
        public async Task<bool> Actualizar(PedidoDetalle modelo)
        {
            _dbcontext.PedidoDetalles.Update(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            PedidoDetalle modelo = _dbcontext.PedidoDetalles.First(c => c.IdPedido == id);
            _dbcontext.PedidoDetalles.Remove(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Insertar(PedidoDetalle modelo)
        {
            _dbcontext.PedidoDetalles.Add(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<PedidoDetalle> Obtener(int id)
        {
            return await _dbcontext.PedidoDetalles.FindAsync(id);
        }

        public async Task<IQueryable<PedidoDetalle>> ObtenerTodos()
        {
            IQueryable<PedidoDetalle> queryPedidoDetalleSQL = _dbcontext.PedidoDetalles;
            return queryPedidoDetalleSQL;
        }
    }
}
