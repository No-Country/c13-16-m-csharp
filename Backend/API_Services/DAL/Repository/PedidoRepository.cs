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
    public class PedidoRepository : IGenericRepository<Pedido>
    {
        private readonly AppserviceContext _dbcontext;
        public PedidoRepository(AppserviceContext dbcontext)
        {

            _dbcontext = dbcontext;

        }

        public async Task<bool> Actualizar(Pedido modelo)
        {
            _dbcontext.Pedidos.Update(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            Pedido modelo = _dbcontext.Pedidos.First(c => c.IdPedido == id);
            _dbcontext.Pedidos.Remove(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Insertar(Pedido modelo)
        {
            _dbcontext.Pedidos.Add(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<Pedido> Obtener(int id)
        {
            return await _dbcontext.Pedidos.FindAsync(id);
        }

        public async Task<IQueryable<Pedido>> ObtenerTodos()
        {
            IQueryable<Pedido> queryPedidoSQL = _dbcontext.Pedidos;
            return queryPedidoSQL;
        }
    }
}
