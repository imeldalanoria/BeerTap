using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace BeerTap.DAL
{
    public abstract class RepositoryBase<TEntity> where TEntity : class
    {
        private IDbSet<TEntity> _entities = null;
        private DbContext _uow = null;

        public RepositoryBase(DbContext context)
        {
            _entities = context.Set<TEntity>();
            _uow = context;
        }

        public virtual void Create(TEntity entity)
        {
            _entities.Add(entity);
        }

        public virtual List<TEntity> Get()
        {
            return _entities.ToList();
        }

        public virtual List<TEntity> Get(Expression<Func<TEntity,bool>> whereExp)
        {
            return _entities.Where(whereExp).ToList();
        }

        public virtual TEntity Get(object id)
        {
            return _entities.Find(id);
        }

        public virtual void Update(TEntity entity)
        {
            _uow.Entry<TEntity>(entity).State = EntityState.Modified;
        }

        public virtual void Delete(TEntity entity)
        {
            _entities.Remove(entity);
        }

        public virtual void Delete(object id)
        {
            var entity = Get(id);
            _entities.Remove(entity);
        }

        public virtual void SaveChanges()
        {
            _uow.SaveChanges();
        }
}
}
