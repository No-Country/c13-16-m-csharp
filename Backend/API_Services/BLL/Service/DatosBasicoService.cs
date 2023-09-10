using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API_Services.Models;
using API_Services.DAL;
using API_Services.DAL.Repository;
using Microsoft.EntityFrameworkCore;

namespace API_Services.BLL.Service
{
    public class DatosBasicoService : IDatosBasicoService
    {
        private readonly IGenericRepository<DatosBasico> _DatosRepo;
        public DatosBasicoService(IGenericRepository<DatosBasico> datosRepo)
        {

            _DatosRepo = datosRepo;

        }

        public async Task<bool> Actualizar(DatosBasico modelo)
        {
            return await _DatosRepo.Actualizar(modelo);
        }

        public async Task<bool> Eliminar(int id)
        {
           return await _DatosRepo.Eliminar(id);
        }

        public async Task<bool> Insertar(DatosBasico modelo)
        {
            return await _DatosRepo.Insertar(modelo);
        }

        public async Task<IQueryable<DatosBasico>> ObtenerTodos()
        {
            return await _DatosRepo.ObtenerTodos(); 
        }


        public async Task<DatosBasico> Obtener_calificacion(string calificacion)
        {
            IQueryable<DatosBasico> querySQL = await _DatosRepo.ObtenerTodos();
            DatosBasico datos = querySQL.Where(c => c.Calificacion == calificacion).FirstOrDefault();
            return datos;
        }

        public async Task<DatosBasico> Obtener_perfil(int id)
        {
            IQueryable<DatosBasico> querySQL = await _DatosRepo.ObtenerTodos();
            DatosBasico datos = querySQL.Where(c => c.IdPerfil == id).FirstOrDefault();
            return datos;
        }

        public async Task<DatosBasico> Obtnener(int id)
        {
            return await _DatosRepo.Obtener(id);
        }
    }
}
