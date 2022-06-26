﻿using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NewGenerationBlog.Shared.Data.Abstract
{
    public interface IGenericRepositoryBase<T> where T : class
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAll(Func<IQueryable<T>, IIncludableQueryable<T, object>> include);
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>> include);
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate = null,
           Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
           Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
           int? skip = null, int? take = null);

        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate = null,
         Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
        string orderBy = null, string orderDirection = "asc",
         int? skip = null, int? take = null);

        Task<IQueryable<T>> GetAllAsync();
        Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> predicate);
        Task<IQueryable<T>> GetAllAsync(Func<IQueryable<T>, IIncludableQueryable<T, object>> include);
        Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>> include);

        Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            int? skip = null, int? take = null);
        Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null,
             Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
                string orderBy = null, string orderDirection = "asc",
             int? skip = null, int? take = null);

        T GetSingle(
          Expression<Func<T, bool>> predicate = null,
          Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);

        Task<T> GetSingleAsync(
          Expression<Func<T, bool>> predicate = null,
          Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);

        void Add(T toAdd);
        Task AddAsync(T entity);
        T Update(T toUpdate);
        Task<T> UpdateAsync(T entity);
        void Delete(T entity);
        Task DeleteAsync(T entity);
        void Delete(Expression<Func<T, bool>> predicate);

        int Count();
        int Count(Expression<Func<T, bool>> predicate);
    }
}