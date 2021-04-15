using Core.Entities.Conrete;
using Core.Utilities.Results.Abstract;

using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
   public interface IUserService
    {
        IDataResult<List<User>> GetAll(Expression<Func<User, bool>> filter = null);
        Task<List<User>> GetAllAsync(Expression<Func<User, bool>> filter = null);
        IDataResult<User> Find(Expression<Func<User, bool>> filter);
        Task<User> FindAsync(Expression<Func<User, bool>> filter);
        IDataResult<User> GetById(int id);
        Task<User> GetByIdAsync(int id);
        IResult Add(User user);
        IResult AddRange(List<User> users);
        IResult Delete(User user);
        IResult DeleteRange(List<User> users);
        IResult Update(User user);
        IResult UpdateRange(List<User> users);
        IResult Exist(Expression<Func<User, bool>> filter);
    }
}
