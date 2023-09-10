using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API_Services.DAL;
using API_Services.DAL.DataContext;
using API_Services.Models;

namespace API_Services.DAL.Repository
{
    public class DatosBasicoRepository : IGenericRepository<DatosBasico>
    {
        private readonly AppserviceContext _dbcontext;

        public DatosBasicoRepository(AppserviceContext dbcontext)
        {

            _dbcontext = dbcontext; 

        }

        public async Task<bool> Actualizar(DatosBasico modelo)
        {
            _dbcontext.DatosBasicos.Update(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            DatosBasico modelo = _dbcontext.DatosBasicos.First(c => c.IdPerfil == id);
            _dbcontext.DatosBasicos.Remove(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Insertar(DatosBasico modelo)
        {
            _dbcontext.DatosBasicos.Add(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<DatosBasico> Obtener(int id)
        {
            return await _dbcontext.DatosBasicos.FindAsync(id);
        }
        public async Task<IQueryable<DatosBasico>> ObtenerTodos()
        {
            IQueryable<DatosBasico> queryDatosSQL = _dbcontext.DatosBasicos;
            return queryDatosSQL;
        }
    }
}
