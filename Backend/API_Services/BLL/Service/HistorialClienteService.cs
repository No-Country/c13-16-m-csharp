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
    public class HistorialClienteService : IHistorialClienteService
    {
        private readonly IGenericRepository<HistorialCliente> _HistoriaCliRepo;

        public HistorialClienteService(IGenericRepository<HistorialCliente> historiaCliRepo)
        {

            _HistoriaCliRepo = historiaCliRepo;

        }

        public async Task<bool> Actualizar(HistorialCliente modelo)
        {
            return await _HistoriaCliRepo.Actualizar(modelo);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await _HistoriaCliRepo.Eliminar(id);
        }

        public async Task<bool> Insertar(HistorialCliente modelo)
        {
            return await _HistoriaCliRepo.Insertar(modelo);
        }

        public async Task<IQueryable<HistorialCliente>> ObtenerTodos()
        {
            return await _HistoriaCliRepo.ObtenerTodos();
        }

        public async Task<HistorialCliente> Obtenerxnombre(string nombre)
        {
            throw new NotImplementedException();
        }

        public async Task<HistorialCliente> Obtnener(int id)
        {
            return await _HistoriaCliRepo.Obtener(id);            
        }
    }
}
