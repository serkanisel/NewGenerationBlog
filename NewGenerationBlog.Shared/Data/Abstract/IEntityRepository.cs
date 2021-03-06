using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using NewGenerationBlog.Shared.Entities.Abstract;

namespace NewGenerationBlog.Shared.Data.Abstract
{
    public interface IEntityRepository<T> where T : class, IEntity , new()
    {
        //sample usage of method :  var kullanici = repository.GetAsync(k => k.Id==15, k => k.users, k => k.comments) 
        Task<T> GetAsync(Expression<Func<T,bool>> predicate, params Expression<Func<T,object>>[] includeProperties);

        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, int? take = null,int? skip=null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, params Expression<Func<T, object>>[] includeProperties);

        Task AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);

        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);

        Task<int> CountAsync(Expression<Func<T, bool>> predicate);

        Task<IList<T>> Find(Expression<Func<T, bool>> predicate);

    }
}
