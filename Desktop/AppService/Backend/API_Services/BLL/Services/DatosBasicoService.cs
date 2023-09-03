using System.Linq;
using System.Threading.Tasks;
using API_Services.DAL.Repository;
using API_Services.Models;

namespace API_Services.BLL.Services
{
    public class DatosBasicoService : IDatosBasicoService
    {
        private readonly IGenericRepository<DatosBasico> _datosBasicoRepository;

        public DatosBasicoService(IGenericRepository<DatosBasico> datosBasicoRepository)
        {
            _datosBasicoRepository = datosBasicoRepository;
        }

        public async Task<bool> Insertar(DatosBasico modelo)
        {
            // Realizar validaciones aquí
            if (await ValidarId(modelo.IdDatos) &&
                await ValidarIdPerfil(modelo.IdPerfil) &&
                await ValidarIdUsuario(modelo.IdUsuarios) &&
                await ValidarNombres(modelo.Nombres) &&
                await ValidarApellidos(modelo.Apellidos) &&
                await ValidarIDNacional(modelo.Idnacional) &&
                await ValidarDireccion(modelo.Direccion) &&
                await ValidarCelular(modelo.Celular) &&
                await ValidarTelfLocal(modelo.TelfLocal) &&
                await ValidarReferidos(modelo.Referidos) &&
                await ValidarCalificacion(modelo.Calificacion))
            {
                return await _datosBasicoRepository.Insertar(modelo);
            }
            return false;
        }

        public async Task<bool> Actualizar(DatosBasico modelo)
        {
            // Realizar validaciones aquí
            if (await ValidarId(modelo.IdDatos) &&
                await ValidarIdPerfil(modelo.IdPerfil) &&
                await ValidarIdUsuario(modelo.IdUsuarios) &&
                await ValidarNombres(modelo.Nombres) &&
                await ValidarApellidos(modelo.Apellidos) &&
                await ValidarIDNacional(modelo.Idnacional) &&
                await ValidarDireccion(modelo.Direccion) &&
                await ValidarCelular(modelo.Celular) &&
                await ValidarTelfLocal(modelo.TelfLocal) &&
                await ValidarReferidos(modelo.Referidos) &&
                await ValidarCalificacion(modelo.Calificacion))
            {
                return await _datosBasicoRepository.Actualizar(modelo);
            }
            return false;
        }

        public async Task<bool> Eliminar(int id)
        {
            return await _datosBasicoRepository.Eliminar(id);
        }

        public async Task<DatosBasico> Obtener(int id)
        {
            return await _datosBasicoRepository.Obtener(id);
        }

        public async Task<IQueryable<DatosBasico>> ObtenerTodos()
        {
            return await _datosBasicoRepository.ObtenerTodos();
        }

        public async Task<bool> ValidarId(int id)
        {
            // Implementa la validación de Id
            // Retorna true si la validación pasa, de lo contrario false
            return true;
        }

        public async Task<bool> ValidarIdPerfil(int idPerfil)
        {
            // Implementa la validación de IdPerfil
            // Retorna true si la validación pasa, de lo contrario false
            return true;
        }

        public async Task<bool> ValidarIdUsuario(int? idUsuario)
        {
            // Implementa la validación de IdUsuario
            // Retorna true si la validación pasa, de lo contrario false
            if (idUsuario.HasValue)
            {
                // Realiza la validación aquí, por ejemplo, verifica si el valor es válido.
                // Si la validación es exitosa, devuelve true; de lo contrario, devuelve false.
                // Puedes agregar más lógica de validación aquí según tus requisitos.
                return true;
            }
            return false;
        }


        public async Task<bool> ValidarNombres(string nombres)
        {
            // Implementa la validación de nombres
            // Retorna true si la validación pasa, de lo contrario false
            return true;
        }

        public async Task<bool> ValidarApellidos(string apellidos)
        {
            // Implementa la validación de apellidos
            // Retorna true si la validación pasa, de lo contrario false
            return true;
        }

        public async Task<bool> ValidarIDNacional(string idNacional)
        {
            // Implementa la validación de IDNacional
            // Retorna true si la validación pasa, de lo contrario false
            return true;
        }

        public async Task<bool> ValidarDireccion(string direccion)
        {
            // Implementa la validación de dirección
            // Retorna true si la validación pasa, de lo contrario false
            return true;
        }

        public async Task<bool> ValidarCelular(string celular)
        {
            // Implementa la validación de celular
            // Retorna true si la validación pasa, de lo contrario false
            return true;
        }

        public async Task<bool> ValidarTelfLocal(string telfLocal)
        {
            // Implementa la validación de telfLocal
            // Retorna true si la validación pasa, de lo contrario false
            return true;
        }

        public async Task<bool> ValidarReferidos(string referidos)
        {
            // Implementa la validación de referidos
            // Retorna true si la validación pasa, de lo contrario false
            return true;
        }

        public async Task<bool> ValidarCalificacion(string calificacion)
        {
            // Implementa la validación de calificacion
            // Retorna true si la validación pasa, de lo contrario false
            return true;
        }
    }
}
