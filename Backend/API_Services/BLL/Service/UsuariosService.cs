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
    public class UsuariosService : IUsuariosService
    {
        private readonly IGenericRepository<Usuario> _UsuarioRepo;

        public UsuariosService(IGenericRepository<Usuario> UsuarioRepo)
        {
            _UsuarioRepo = UsuarioRepo; 
        }

        public Task<Usuario> Acceso(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Actualizar(Usuario modelo)
        {
           return await _UsuarioRepo.Actualizar(modelo);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await _UsuarioRepo.Eliminar(id);
        }

        public async Task<Usuario> EnviarCorreo(string correo)
        {
            throw new NotImplementedException();
        }

        public async Task<Usuario> GenerarToken(string token)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Insertar(Usuario modelo)
        {
            return await _UsuarioRepo.Insertar(modelo);
        }

        public async Task<IQueryable<Usuario>> ObtenerTodos()
        {
            return await _UsuarioRepo.ObtenerTodos();
        }

        public async Task<Usuario> Obtenerxnombre(string usuario)
        {
            IQueryable<Usuario> querySQL = await _UsuarioRepo.ObtenerTodos();
            Usuario Usuarios = querySQL.Where(c => c.NombreUsuario == usuario).FirstOrDefault();
            return Usuarios; 
        }

        public async Task<Usuario> Obtnener(int id)
        {
            return await _UsuarioRepo.Obtener(id);
        }
    }
}
