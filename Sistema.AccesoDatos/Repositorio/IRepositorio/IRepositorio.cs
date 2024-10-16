﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.AccesoDatos.Repositorio.IRepositorio
{
    public interface IRepositorio<T> where T : class
    {
        Task<T> Obtener(int id);

        Task<IEnumerable<T>> ObtenerTodos(
            Expression<Func<T, bool>> Filtro = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            bool isTracking = true);

        Task Agregar(T entidad);

        void Remover(T entidad);

        void RemoverRango(IEnumerable<T> entidad);
    }
}
