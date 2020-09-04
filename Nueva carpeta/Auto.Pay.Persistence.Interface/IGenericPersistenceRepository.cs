using Auto.Pay.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Auto.Pay.Persistence.Interface
{
    public interface IGenericPersistenceRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> AsQueryable();
        TEntity FindByIdConDependencia(long id);

        IEnumerable<TEntity> FindAllConDependencia();

        DataCollection<TEntity> GetAll(int page,int take);

        TEntity GetById(long id);

        TEntity Add(TEntity entity);

        IEnumerable<TEntity> AddRange(IEnumerable<TEntity> listaEntity);

        TEntity Update(TEntity entity);
        IEnumerable<TEntity> UpdateRange(IEnumerable<TEntity> listaEntity);
        bool Exists(long id);

        bool Exists();

        bool Exists(TEntity entity);

        TEntity Remove(long id);

        TEntity Remove(TEntity entity);

        IEnumerable<TEntity> RemoveRange(IEnumerable<TEntity> listEntity);

        IEnumerable<TEntity> RemoveRange(IEnumerable<long> listId);
        T FindSingle<T>(Expression<Func<T, bool>> predicate) where T : class;
        T FindFirstOrDefault<T>(Expression<Func<T, bool>> predicate) where T : class;

        //IEnumerable<TEntity> GetRemoved();
    }
}
