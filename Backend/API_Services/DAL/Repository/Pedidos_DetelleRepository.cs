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
    public class Pedidos_DetelleRepository : IGenericRpository<PedidoDetalle>
    {
        private readonly AppserviceContext _dbcontext;
        public Pedidos_DetelleRepository(AppserviceContext dbcontext)
        {

            _dbcontext = dbcontext;

        }
        public async Task<bool> Actualizar(PedidoDetalle detalle_modelo)
        {
            _dbcontext.PedidoDetalles.Update(detalle_modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            PedidoDetalle detalle_modelo = _dbcontext.PedidoDetalles.First(c => c.IdPedido == id);
            return true;
        }

        public async Task<bool> Insertar(PedidoDetalle detalle_modelo)
        {
            _dbcontext.PedidoDetalles.Add(detalle_modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<IQueryable<PedidoDetalle>> ObtenerTodos()
        {
            IQueryable<PedidoDetalle> queryPedidoDetalleSQL = _dbcontext.PedidoDetalles;
            return queryPedidoDetalleSQL;
        }
         
        public async Task<PedidoDetalle> Obtnener(int id)
        {
            return await _dbcontext.PedidoDetalles.FindAsync(id);
        }
    }
}
