using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Services.DAL.Repository;
using API_Services.Models;

namespace API_Services.BLL.Services
{
    public class PerfilNegocioService : IPerfilNegocioService
    {
        private readonly IGenericRepository<PerfilNegocio> _perfilNegocioRepository;

        public PerfilNegocioService(IGenericRepository<PerfilNegocio> perfilNegocioRepository)
        {
            _perfilNegocioRepository = perfilNegocioRepository;
        }

        public async Task<bool> CrearPerfilNegocio(PerfilNegocio modelo)
        {
            // Realizar validaciones aquí si es necesario

            return await _perfilNegocioRepository.Insertar(modelo);
        }

        public async Task<bool> ActualizarPerfilNegocio(PerfilNegocio modelo)
        {
            // Realizar validaciones aquí si es necesario

            return await _perfilNegocioRepository.Actualizar(modelo);
        }

        public async Task<bool> EliminarPerfilNegocio(int id)
        {
            return await _perfilNegocioRepository.Eliminar(id);
        }

        public async Task<IQueryable<PerfilNegocio>> VerPerfilesNegocios()
        {
            return await _perfilNegocioRepository.ObtenerTodos();
        }

        public async Task<PerfilNegocio> DetallesPerfilNegocio(int id)
        {
            return await _perfilNegocioRepository.Obtener(id);
        }

    }
}
