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
    public class HistorialClienteRepository : IGenericRepository<HistorialCliente>
    {
        private readonly AppserviceContext _dbcontext;
        public HistorialClienteRepository(AppserviceContext dbcontext)
        {

            _dbcontext = dbcontext;

        }
        public async Task<bool> Actualizar(HistorialCliente modelo)
        {
            _dbcontext.HistorialClientes.Update(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            HistorialCliente modelo = _dbcontext.HistorialClientes.First(c => c.IdPedido == id);
            _dbcontext.HistorialClientes.Remove(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Insertar(HistorialCliente modelo)
        {
            _dbcontext.HistorialClientes.Add(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<HistorialCliente> Obtener(int id)
        {
            return await _dbcontext.HistorialClientes.FindAsync(id);
        }

        public async Task<IQueryable<HistorialCliente>> ObtenerTodos()
        {
            IQueryable<HistorialCliente> queryHistoriaClienteSQL = _dbcontext.HistorialClientes;
            return queryHistoriaClienteSQL;

        }
    }
}
