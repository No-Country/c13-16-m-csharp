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
    public class ProveedoreService : IProveedoreService
    {
        private readonly IGenericRepository<Proveedore> _ProveedorRepo;

        public ProveedoreService(IGenericRepository<Proveedore> proveedorRepo)
        {

            _ProveedorRepo = proveedorRepo;

        }

        public async Task<bool> Actualizar(Proveedore modelo)
        {
            return await _ProveedorRepo.Actualizar(modelo);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await _ProveedorRepo.Eliminar(id);
        }

        public async Task<bool> Insertar(Proveedore modelo)
        {
            return await _ProveedorRepo.Insertar(modelo);
        }

        public async Task<IQueryable<Proveedore>> ObtenerTodos()
        {
            return await _ProveedorRepo.ObtenerTodos();
        }

        public async Task<Proveedore> Obtenerxnombre(string nombre)
        {
            throw new NotImplementedException();
        }

        public async Task<Proveedore> Obtnener(int id)
        {
            return await _ProveedorRepo.Obtener(id);
        }
    }
}
