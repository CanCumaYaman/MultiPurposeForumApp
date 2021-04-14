
using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Abstract
{
    public interface IGenericRepository<T> where T:class,IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null);
        T Find(Expression<Func<T, bool>> filter);
        Task<T> FindAsync(Expression<Func<T, bool>> filter);
        T GetById(int id);
        Task<T> GetByIdAsync(int id);
        void Add(T entity);
        void AddRange(List<T> entities);
        void Delete(T entity);
        void DeleteRange(List<T> entities);
        void Update(T entity);
        void UpdateRange(List<T> entities);

        bool Exist(Expression<Func<T, bool>> filter);
        
    }
}
