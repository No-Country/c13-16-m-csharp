using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API_Services.Models;

namespace API_Services.BLL.Service
{
    public interface IUsuariosService
    {
        Task<bool> Insertar(Usuario modelo);

        Task<bool> Actualizar(Usuario modelo);

        Task<bool> Eliminar(int id);

        Task<Usuario> Obtnener(int id);

        Task<IQueryable<Usuario>> ObtenerTodos();
        //Funciones Adicionales 

        Task<Usuario>Obtenerxnombre(string usuario);

        Task<Usuario> GenerarToken(string token);

        Task<Usuario> EnviarCorreo(string correo);

        Task<Usuario> Acceso(int id);
    }
}
