using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Services.Models;
using API_Services.Models.ViewModels;
using API_Services.DAL.Repository;

namespace API_Services.BLL.Service
{
    public class ServicioService : IServicioService
    {
        private readonly IGenericRepository<Servicio> _servicioRepo;

        public ServicioService(IGenericRepository<Servicio> servicioRepo)
        {
            _servicioRepo = servicioRepo;
        }

        public async Task<bool> Actualizar(VMServicio modelo)
        {
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            return true;
        }

        public async Task<bool> Insertar(VMServicio modelo)
        {
            return true;
        }

        public async Task<VMServicio> Obtener(int id)
        {
            return null;
        }

        public async Task<IQueryable<VMServicio>> ObtenerTodos()
        {
            return new List<VMServicio>().AsQueryable();
        }

        public async Task<VMServicio> ObtenerPorNombreCategoria(string nombreCategoria)
        {
            
            return null;
        }
    }
}
