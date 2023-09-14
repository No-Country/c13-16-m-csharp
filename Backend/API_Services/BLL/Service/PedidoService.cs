using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API_Services.Models;
using API_Services.DAL;
using API_Services.DAL.Repository;

namespace API_Services.BLL.Service
{
    public class PedidoService : IPedidoService
    {
        private readonly IGenericRepository<Pedido> _PedidoRepo;
        public PedidoService(IGenericRepository<Pedido> PedidoRepo)
        {
            _PedidoRepo = PedidoRepo;
        }
        
        public async Task<bool> Actualizar(Pedido modelo)
        {
            return await _PedidoRepo.Actualizar(modelo);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await _PedidoRepo.Eliminar(id);
        }

        public async Task<bool> Insertar(Pedido modelo)
        {
            return await _PedidoRepo.Insertar(modelo);
        }

        public async Task<IQueryable<Pedido>> ObtenerTodos()
        {
            return await _PedidoRepo.ObtenerTodos();
        }

        public async Task<Pedido> Obtenerxnombre(string nombre)
        {
            throw new NotImplementedException();
        }

        public async Task<Pedido> Obtnener(int id)
        {
            return await _PedidoRepo.Obtener(id);
        }
    }
}
