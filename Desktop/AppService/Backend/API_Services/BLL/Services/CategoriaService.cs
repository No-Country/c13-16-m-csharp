using System;
using System.Linq;
using System.Threading.Tasks;
using API_Services.DAL.Repository;
using API_Services.Models;

namespace API_Services.BLL.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly IGenericRepository<Categoria> _categoriaRepository;

        public CategoriaService(IGenericRepository<Categoria> categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public async Task<bool> CrearCategoria(Categoria categoria)
        {
            // Aquí puedes realizar validaciones si es necesario antes de crear la categoría.
            // Por ejemplo, asegurarte de que no exista una categoría con el mismo nombre.
            // Si las validaciones pasan, puedes insertar la categoría en la base de datos.
            return await _categoriaRepository.Insertar(categoria);
        }

        public async Task<bool> ActualizarCategoria(Categoria categoria)
        {
            // Aquí puedes realizar validaciones si es necesario antes de actualizar la categoría.
            // Por ejemplo, asegurarte de que la categoría que intentas actualizar exista.
            // Si las validaciones pasan, puedes actualizar la categoría en la base de datos.
            return await _categoriaRepository.Actualizar(categoria);
        }

        public async Task<bool> EliminarCategoria(int id)
        {
            // Aquí puedes realizar validaciones si es necesario antes de eliminar la categoría.
            // Por ejemplo, asegurarte de que la categoría que intentas eliminar exista.
            // Si las validaciones pasan, puedes eliminar la categoría de la base de datos.
            return await _categoriaRepository.Eliminar(id);
        }

        public async Task<IQueryable<Categoria>> VerCategorias()
        {
            // Aquí obtienes todas las categorías disponibles desde la base de datos.
            return await _categoriaRepository.ObtenerTodos();
        }

        public async Task<Categoria> DetallesCategoria(int id)
        {
            // Aquí puedes obtener información detallada de una categoría específica, incluyendo
            // los perfiles de negocios relacionados con esa categoría si es necesario.
            return await _categoriaRepository.Obtener(id);
        }
    }
}
