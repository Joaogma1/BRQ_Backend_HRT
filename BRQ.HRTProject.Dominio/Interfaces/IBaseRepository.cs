using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BRQ.HRTProject.Dominio.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        void Add(TEntity obj);

        TEntity GetById(int id);

        IQueryable<TEntity> GetAll();

        void Update(TEntity obj);

        void Remove(int id);
    }
}