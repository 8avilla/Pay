using Auto.Pay.Persistence.Data;
using Auto.Pay.Persistence.Entities;
using Auto.Pay.Persistence.Interface;
using Auto.Pay.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;

namespace Auto.Pay.Persistence.Repository
{
    public class GenericPersistenceRepository<TEntity> : IGenericPersistenceRepository<TEntity>
        where TEntity : class, IEntityPersistence
    {
        private readonly ContextPay _contexto;

        public GenericPersistenceRepository(ContextPay dbContext)
        {
            _contexto = dbContext;
        }

        public DataCollection<TEntity> GetAll(int page, int take)
        {
            return _contexto.Set<TEntity>().OrderByDescending(e => e.CreationDate).GetPaged(page, take);
        }

        public virtual T FindSingleBy<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            if (predicate != null)
            {
                return _contexto.Set<T>().Where(predicate).SingleOrDefault();
            }
            else
            {
                throw new ArgumentNullException("Predicate value must be passed to FindSingleBy<T>.");
            }
        }

        public TEntity GetById(long id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("The ID parameter of the object to search is less than or equal to zero");
            }

            OrderEP h = _contexto.Order.FirstOrDefault(o => o.Id == id);

            return _contexto.Set<TEntity>()
                .FirstOrDefault(e => e.Id == id);
        }

        public TEntity Add(TEntity entity)
        {
            if (entity.IsNull())
            {
                throw new ArgumentNullException();
            }

            if (entity.Id != 0)
            {
                throw new ArgumentException("The parameter ID of the object to add is not zero", "Id");
            }

            entity.CreationDate = DateTime.Now;

            return _contexto.Set<TEntity>().Add(entity).Entity;
        }

        public TEntity Update(TEntity entity)
        {
            if (entity.IsNull())
            {
                throw new ArgumentNullException();
            }

            if (entity.Id <= 0)
            {
                throw new ArgumentException("The parameter ID of the object to be modified less than or equal to zero", "Id");
            }

            return _contexto.Set<TEntity>().Update(entity).Entity;
        }

        public IEnumerable<TEntity> AddRange(IEnumerable<TEntity> listEntity)
        {
            if (listEntity.IsNull())
            {
                throw new ArgumentNullException();
            }

            foreach (TEntity entity in listEntity)
            {
                if (entity.IsNull())
                {
                    throw new ArgumentException("The list to add contains a null object");
                }

                if (entity.Id != 0)
                {
                    throw new ArgumentException("The list to add contains an object with ID parameter other than zero", "Id");
                }
            }

            _contexto.Set<TEntity>().AddRange(listEntity);

            return listEntity;
        }

        public IEnumerable<TEntity> UpdateRange(IEnumerable<TEntity> listEntity)
        {
            if (listEntity.IsNull())
            {
                throw new ArgumentNullException();
            }

            foreach (TEntity entity in listEntity)
            {
                if (entity.IsNull())
                {
                    throw new ArgumentNullException("The list to modify contains a null object");
                }

                if (entity.Id <= 0)
                {
                    throw new ArgumentException("The list to modify contains an object with ID parameter less than or equal to zero", "Id");
                }
            }

            _contexto.Set<TEntity>().UpdateRange(listEntity);
            return listEntity;
        }

        public bool Exists(long id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("The ID of the object to check if it exists must be greater than zero", "Id");
            }

            return _contexto.Set<TEntity>().Any(t => t.Id == id);
        }

        public bool Exists()
        {
            return _contexto.Set<TEntity>().Any();
        }

        public bool Exists(TEntity entity)
        {
            if (entity.IsNull())
            {
                throw new ArgumentNullException();
            }


            if (entity.Id <= 0)
            {
                throw new ArgumentException("The ID of the object to check if it exists must be greater than zero", "Id");
            }

            return _contexto.Set<TEntity>().Any(t => t.Id == entity.Id);
        }

        public TEntity Remove(long id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("The ID to delete must be greater than zero", "Id");
            }

            TEntity entity = _contexto.Set<TEntity>().FirstOrDefault(e => e.Id == id);

            if (entity.IsNull())
            {
                throw new ArgumentNullException("The object to delete is null");
            }


            if (id <= 0)
            {
                throw new ArgumentException("The ID of the object to delete must be greater than zero", "Id");
            }

            _contexto.Set<TEntity>().Remove(entity);
            return entity;
        }

        public TEntity Remove(TEntity entity)
        {
            if (entity.IsNull())
            {
                throw new ArgumentNullException();
            }


            if (entity.Id <= 0)
            {
                throw new ArgumentException("The ID of the object to be removed must be greater than zero", "Id");
            }

            _contexto.Set<TEntity>().Remove(entity);
            return entity;

        }

        public IEnumerable<TEntity> RemoveRange(IEnumerable<TEntity> listEntity)
        {
            if (listEntity.IsNull())
            {
                throw new ArgumentNullException();
            }

            foreach (TEntity entity in listEntity)
            {
                if (entity.IsNull())
                {
                    throw new ArgumentNullException("The list to delete contains a null object");
                }

                if (entity.Id <= 0)
                {
                    throw new ArgumentException("The list to delete contains an object with parameter ID less than or equal to zero", "Id");
                }
            }

            _contexto.Set<TEntity>().RemoveRange(listEntity);

            return listEntity;
        }



        //public IEnumerable<TEntity> GetRemoved()
        //{
        //    return _contexto.Set<TEntity>()..ToList();
        //}

        public IEnumerable<TEntity> RemoveRange(IEnumerable<long> listId)
        {
            if (listId.IsNull())
            {
                throw new ArgumentNullException();
            }

            List<TEntity> listEntity = new List<TEntity>();

            foreach (long id in listId)
            {

                if (id <= 0)
                {
                    throw new ArgumentException("The list to delete contains an object with parameter ID less than or equal to zero", "Id");
                }

                TEntity entity = _contexto.Set<TEntity>().FirstOrDefault(e => e.Id == id);

                if (entity.IsNull())
                {
                    throw new ArgumentNullException("An object from the wanted list to delete does not exist in the database");
                }

                if (entity.Id <= 0)
                {
                    throw new ArgumentException("An object in the list to be removed has an ID parameter less than or equal to zero", "Id");
                }

                listEntity.Add(entity);
            }


            _contexto.Set<TEntity>().UpdateRange(listEntity);
            return listEntity;
        }

        public TEntity FindByIdConDependencia(long id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<TEntity> FindAllConDependencia()
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<TEntity> AsQueryable()
        {
            return _contexto.Set<TEntity>().AsQueryable();
        }

        public TEntity FindByIdConDependencia(int id)
        {
            throw new NotImplementedException();
        }

        public TEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Exists(int id)
        {
            throw new NotImplementedException();
        }

        public TEntity Remove(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> RemoveRange(IEnumerable<int> listaId)
        {
            throw new NotImplementedException();
        }
    }
}