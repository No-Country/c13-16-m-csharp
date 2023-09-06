﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API_Services.DAL;

namespace API_Services.DAL.Repository
{
    public interface IGenericRepository<TEntityModel> where TEntityModel : class

    {
        Task<bool> Insertar(TEntityModel modelo);

        Task<bool> Actualizar(TEntityModel modelo);

        Task<bool> Eliminar(int id);

        Task<TEntityModel> Obtener(int id); // Corregido

        Task<IQueryable<TEntityModel>> ObtenerTodos();
    }
}
