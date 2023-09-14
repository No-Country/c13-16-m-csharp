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
    public class PedidoDetalleService : IPedidoDetalleService
    {
        private readonly IGenericRepository<PedidoDetalle> _PedidodetalleRepo;
        public PedidoDetalleService(IGenericRepository<PedidoDetalle> pedidodetalleRepo)
        {

            _PedidodetalleRepo = pedidodetalleRepo;

        }
        public async Task<bool> Actualizar(PedidoDetalle modelo)
        {
            return await _PedidodetalleRepo.Actualizar(modelo);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await _PedidodetalleRepo.Eliminar(id);
        }

        public async Task<bool> Insertar(PedidoDetalle modelo)
        {
            return await _PedidodetalleRepo.Insertar(modelo);
        }

        public async Task<IQueryable<PedidoDetalle>> ObtenerTodos()
        {
            return await _PedidodetalleRepo.ObtenerTodos();
        }

        public async Task<PedidoDetalle> Obtenerxnombre(string nombre)
        {
            throw new NotImplementedException();
        }

        public async Task<PedidoDetalle> Obtnener(int id)
        {
            return await _PedidodetalleRepo.Obtener(id);
        }
    }
}
