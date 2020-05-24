using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Interfaces
{
    public interface IRepository<TEntity> where TEntity : IIDentity
    {
        void Add(TEntity entity);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity entity);
        void Delete(int id);

    }
}
