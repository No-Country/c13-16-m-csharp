﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API_Services.Models;
using API_Services.DAL;
using API_Services.DAL.Repository;

namespace API_Services.BLL.Service
{
    public class RolService : IRolService
    {
        private readonly IGenericRepository<Rol> _RolRepo;
        
        public RolService( IGenericRepository<Rol> rolRepo)
        {

            _RolRepo = rolRepo;

        }

        public async Task<bool> Actualizar(Rol modelo)
        { 
            return await _RolRepo.Actualizar(modelo);

        }

        public async Task<bool> Eliminar(int id)
        {
            return await _RolRepo.Eliminar(id);
        }

        public async Task<bool> Insertar(Rol modelo)
        {
            return await _RolRepo.Insertar(modelo);
        }

        public async Task<IQueryable<Rol>> ObtenerTodos()
        {
            return await _RolRepo.ObtenerTodos();
        }

        public async Task<Rol> Obtenerxnombre(string nombre)
        {
            IQueryable<Rol> querySQL = await _RolRepo.ObtenerTodos();
            Rol roles = querySQL.Where(c => c.Roles == nombre).FirstOrDefault();
            return roles;
        }

        public async Task<Rol> Obtnener(int id)
        {
            return await _RolRepo.Obtener(id);
        }
    }
}