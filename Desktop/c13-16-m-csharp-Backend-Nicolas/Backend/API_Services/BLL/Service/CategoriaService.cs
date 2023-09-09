using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Services.Models;
using API_Services.Models.ViewModels;
using API_Services.DAL.Repository;

namespace API_Services.BLL.Service
{
    public class CategoriaService : ICategoriaService
    {
        private readonly IGenericRepository<Categoria> _categoriaRepo;

        public CategoriaService(IGenericRepository<Categoria> categoriaRepo)
        {
            _categoriaRepo = categoriaRepo;
        }

        public async Task<bool> Actualizar(VMCategoria modelo)
        {
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            return true;
        }

        public async Task<bool> Insertar(VMCategoria modelo)
        {
            return true;
        }

        public async Task<VMCategoria> Obtener(int id)
        {
            return null;
        }

        public async Task<IQueryable<VMCategoria>> ObtenerTodos()
        {
            return new List<VMCategoria>().AsQueryable();
        }
    }
}
