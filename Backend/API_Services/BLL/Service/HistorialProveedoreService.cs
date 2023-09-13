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
    public class HistorialProveedoreService : IHistorialProveedoreService
    {
        private readonly IGenericRepository<HistorialProveedore> _HistoriaProRepo;

        public HistorialProveedoreService(IGenericRepository<HistorialProveedore> historiaProRepo)
        {
            _HistoriaProRepo = historiaProRepo;
        }

        public async Task<bool> Actualizar(HistorialProveedore modelo)
        {
            return await _HistoriaProRepo.Actualizar(modelo);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await _HistoriaProRepo.Eliminar(id);
        }
        
        public async Task<bool> Insertar(HistorialProveedore modelo)
        {
            return await _HistoriaProRepo.Insertar(modelo);
        }

        public async Task<IQueryable<HistorialProveedore>> ObtenerTodos()
        {
            return await _HistoriaProRepo.ObtenerTodos();
        }

        public async Task<HistorialProveedore> Obtenerxnombre(string nombre)
        {
            throw new NotImplementedException();
        }

        public async Task<HistorialProveedore> Obtnener(int id)
        {
            return await _HistoriaProRepo.Obtener(id);
        }
    }
}
