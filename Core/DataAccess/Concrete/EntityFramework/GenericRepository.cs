using Core.DataAccess.Abstract;
using Core.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Concrete.EntityFramework
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class,IEntity, new()
        
    {
        private readonly DbContext _context;
        private DbSet<TEntity> _dbSet;
       
        public GenericRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
           
        }
        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null ? _dbSet.ToList() : _dbSet.Where(filter).ToList();
        }
        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            return await _dbSet.ToListAsync();
        }
        public TEntity Find(Expression<Func<TEntity, bool>> filter)
        {
            return _dbSet.SingleOrDefault(filter);

        }
        public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _dbSet.SingleOrDefaultAsync(filter);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            
                return _dbSet.SingleOrDefault(filter);
            
        }
        public TEntity GetById(int id)
        {
            return _dbSet.Find(id);
        }
        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }
        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }
        public void AddRange(List<TEntity> entities)
        {
            _dbSet.AddRange(entities);
            _context.SaveChanges();
        }


        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }

        public void DeleteRange(List<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
            _context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
        }

        public void UpdateRange(List<TEntity> entities)
        {
            _dbSet.AttachRange(entities);
            foreach (TEntity entity in entities)
            {
                _context.Entry(entity).State = EntityState.Modified;
            }
            _context.SaveChanges();
        }
        public bool Exist(Expression<Func<TEntity, bool>> filter)
        {
            return _dbSet.Where(filter).Any();
        }








    }
}
