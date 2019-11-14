
using BRQ.HRTProject.Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BRQ.HRTProject.Infra.Data.Repositorios
{
    public abstract class RepositoryBaseCollaborator<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly ContextoHRT _dbContext;

        protected RepositoryBaseCollaborator(ContextoHRT dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(TEntity obj)
        {
            _dbContext.Set<TEntity>().Add(obj);
            _dbContext.SaveChanges();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().AsNoTracking();
        }

        public TEntity GetById(int id)
        {
            TEntity itemBuscado = _dbContext.Set<TEntity>().Find(id);
            if (itemBuscado == null)
            {
                return itemBuscado; 
            }
            _dbContext.Entry(itemBuscado).State = EntityState.Detached;

            return itemBuscado;
        }

        public void Remove(int id)
        {
            var entity = GetById(id);
            _dbContext.Set<TEntity>().Remove(entity);
            _dbContext.SaveChanges();
        }


        public void Update(TEntity obj)
        {
            _dbContext.Set<TEntity>().Update(obj);
            _dbContext.SaveChanges();
        }
    }
}
