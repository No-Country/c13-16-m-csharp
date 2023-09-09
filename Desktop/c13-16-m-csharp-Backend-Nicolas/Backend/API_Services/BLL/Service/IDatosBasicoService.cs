using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API_Services.Models;

namespace API_Services.BLL.Service
{
    public interface IDatosBasicoService
    {
        Task<bool> Insertar(DatosBasico modelo);

        Task<bool> Actualizar(DatosBasico modelo);

        Task<bool> Eliminar(int id);

        Task<DatosBasico> Obtnener(int id);

        Task<IQueryable<DatosBasico>> ObtenerTodos();

        //Consultas de datos basicos


        Task<DatosBasico> Obtener_calificacion(string calificacion);

        Task<DatosBasico> Obtener_perfil(int id);


    }
}
