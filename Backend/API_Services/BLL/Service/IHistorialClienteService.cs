using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API_Services.Models;

namespace API_Services.BLL.Service
{
    public interface IHistorialClienteService
    {
        Task<bool> Insertar(HistorialCliente modelo);

        Task<bool> Actualizar(HistorialCliente modelo);

        Task<bool> Eliminar(int id);

        Task<HistorialCliente> Obtnener(int id);

        Task<IQueryable<HistorialCliente>> ObtenerTodos();

        Task<HistorialCliente> Obtenerxnombre(string nombre);
    }
}
