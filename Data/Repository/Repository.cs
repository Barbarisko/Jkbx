using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : IDentity
    {
        private readonly DbSet<TEntity> _dbSet;
        private readonly JukeBoxDBContext context;

        public Repository(JukeBoxDBContext context)
        {
            _dbSet = context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public void Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var tEntity = _dbSet.Find(id);
            if (tEntity != null)
            {
                _dbSet.Remove(tEntity);
            }
        }
    }
}
