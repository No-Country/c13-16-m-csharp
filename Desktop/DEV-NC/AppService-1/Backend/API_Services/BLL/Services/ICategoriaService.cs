using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API_Services.Models;

namespace API_Services.BLL.Services
{
    public interface ICategoriaService
    {
        Task<bool> CrearCategoria(Categoria modelo); // Para crear una categoría
        Task<bool> ActualizarCategoria(Categoria modelo); // Para actualizar una categoría
        Task<bool> EliminarCategoria(int id); // Para eliminar una categoría
        Task<IQueryable<Categoria>> VerCategorias(); // Para ver la lista de categorías
        Task<Categoria> DetallesCategoria(int id); // Para obtener detalles de una categoría
    }
}
