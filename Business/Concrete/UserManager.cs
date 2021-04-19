using Business.Abstract;
using Core.Entities.Conrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public IResult Add(User user)
        {
            var result = _userDal.Find(p => p.Email == user.Email);
            if (result != null)
            {
                return new ErrorResult("This User already added");
            }
            _userDal.Add(user);
            return new SuccessResult("Your User successfully posted");
        }

        public IResult AddRange(List<User> users)
        {
            _userDal.AddRange(users);
            return new SuccessResult("Users successfully posted");
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult("Your User successfull deleted");
        }

        public IResult DeleteRange(List<User> users)
        {
            _userDal.DeleteRange(users);
            return new SuccessResult("Users successfully deleted");
        }

        public IResult Exist(Expression<Func<User, bool>> filter)
        {
            if (_userDal.Exist(filter))
            {
                return new SuccessResult("This User exist");
            }
            return new ErrorResult("This User is not registered");
        }

        public IDataResult<User> Find(Expression<Func<User, bool>> filter)
        {
            return new SuccessDataResult<User>(_userDal.Find(filter));
        }

        public Task<User> FindAsync(Expression<Func<User, bool>> filter)
        {
            return _userDal.FindAsync(filter);
        }

        public IDataResult<List<User>> GetAll(Expression<Func<User, bool>> filter = null)
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(filter));
        }

        public Task<List<User>> GetAllAsync(Expression<Func<User, bool>> filter = null)
        {
            return _userDal.GetAllAsync(filter);
        }

        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userDal.GetById(id));
        }

        public Task<User> GetByIdAsync(int id)
        {
            return _userDal.GetByIdAsync(id);
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult("User successfully updated");
        }

        public IResult UpdateRange(List<User> users)
        {
            _userDal.UpdateRange(users);
            return new SuccessResult("Users successfully updated");
        }
        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }
    }
}
