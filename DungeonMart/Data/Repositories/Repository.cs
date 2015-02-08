using System;
using System.Data.Entity;
using System.Linq;
using DungeonMart.Data.DAL;
using DungeonMart.Data.Models.Interfaces;

namespace DungeonMart.Data.Repositories
{
    public abstract class Repository<T> where T : class
    {
        protected readonly IUnitOfWork UnitOfWork;
        protected readonly IDungeonMartContext DBContext;
        protected readonly IDbSet<T> DBSet;

        public IDungeonMartContext Context
        {
            get { return DBContext; }
        }

        protected Repository(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            DBContext = unitOfWork.DbContext;
            DBSet = DBContext.Set<T>();
        }

        public virtual IQueryable<T> GetAll()
        {
            return DBSet;
        }

        public virtual T GetById(int id)
        {
            return DBSet.Find(id);
        }

        public T Add(T entity)
        {
            var auditableEntity = entity as IAuditable;
            if (auditableEntity != null)
            {
                auditableEntity.CreatedDate = DateTime.UtcNow;
                auditableEntity.ModifiedBy = auditableEntity.CreatedBy;
                auditableEntity.ModifiedDate = auditableEntity.CreatedDate;
            }

            var entityState = DBContext.Entry(entity).State;
            if (entityState != EntityState.Detached)
            {
                DBContext.Entry(entity).State = EntityState.Added;
            }
            else
            {
                DBSet.Add(entity);
            }

            // TODO: I have to do this to get an id for proper post responses. Need a better way
            Context.SaveChanges();
            
            return entity;
        }

        public T Update(T entity)
        {
            var auditableEntity = entity as IAuditable;
            if (auditableEntity != null)
            {
                auditableEntity.ModifiedDate = DateTime.UtcNow;
            }

            var entityState = DBContext.Entry(entity).State;
            if (entityState == EntityState.Detached)
            {
                DBSet.Attach(entity);
            }
            DBContext.Entry(entity).State = EntityState.Modified;

            Context.SaveChanges();

            return entity;
        }

        public void Delete(T entity)
        {
            var entityState = DBContext.Entry(entity).State;
            if (entityState != EntityState.Deleted)
            {
                DBContext.Entry(entity).State = EntityState.Deleted;
            }
            else
            {
                DBSet.Attach(entity);
                DBSet.Remove(entity);
            }

            Context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            if (entity == null) return;
            Delete(entity);
        }
    }
}
