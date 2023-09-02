using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API_Services.Models;

namespace API_Services.BLL.Services
{
    public interface IDatosBasicoService
    {
        Task<bool> Insertar(DatosBasico modelo);
        Task<bool> Actualizar(DatosBasico modelo);
        Task<bool> Eliminar(int id);
        Task<DatosBasico> Obtener(int id);
        Task<IQueryable<DatosBasico>> ObtenerTodos();

        Task<bool> ValidarId(int id);
        Task<bool> ValidarIdPerfil(int idPerfil);
        Task<bool> ValidarIdUsuario(int idUsuario);
        Task<bool> ValidarNombres(string nombres);
        Task<bool> ValidarApellidos(string apellidos);
        Task<bool> ValidarIDNacional(string idNacional);
        Task<bool> ValidarDireccion(string direccion);
        Task<bool> ValidarCelular(string celular);
        Task<bool> ValidarTelfLocal(string telfLocal);
        Task<bool> ValidarReferidos(int referidos);
        Task<bool> ValidarCalificacion(int calificacion);
    }
}
