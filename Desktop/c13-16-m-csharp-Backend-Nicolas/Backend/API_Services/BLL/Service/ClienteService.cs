using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Services.Models;
using API_Services.Models.ViewModels;
using API_Services.DAL.Repository;

namespace API_Services.BLL.Service
{
    public class ClienteService : IClienteService
    {
        private readonly IGenericRepository<Cliente> _clienteRepo;

        public ClienteService(IGenericRepository<Cliente> clienteRepo)
        {
            _clienteRepo = clienteRepo;
        }

        public async Task<bool> Actualizar(VMCliente modelo)
        {
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            return true; 
        }

        public async Task<bool> Insertar(VMCliente modelo)
        {
            return true;
        }

        public async Task<VMCliente> Obtener(int id)
        {
            return null; 
        }

        public async Task<IQueryable<VMCliente>> ObtenerTodos()
        {
            return new List<VMCliente>().AsQueryable(); 
        }
    }
}
