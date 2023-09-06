using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API_Services.DAL;
using API_Services.DAL.DataContext;
using API_Services.DAL.Repository;
using API_Services.Models;

namespace API_Services.DAL.Repository
{
    public class UsuarioRepository : IGenericRpository<Usuario>
    {
        private readonly AppserviceContext _dbcontext;
        public UsuarioRepository(AppserviceContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<bool> Actualizar(Usuario modelo)
        {
            _dbcontext.Usuarios.Update(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Insertar(Usuario modelo)
        {
            throw new NotImplementedException();
        }

        public async Task<IQueryable<Usuario>> ObtenerTodos()
        {
            throw new NotImplementedException();
        }

        public async Task<Usuario> Obtnener(int id)
        {
            throw new NotImplementedException();
        }
    }
}
