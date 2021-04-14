using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Core.Utilities.Security.Hashing;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        IUserService _userService;
        public AuthManager(IUserService userService)
        {
            _userService = userService;
        }
        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userCheck = _userService.Find(p => p.Email == userForLoginDto.Email);
            if (userCheck == null)
            {
                return new ErrorDataResult<User>("Invalid User");
            }
            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userCheck.Data.PasswordHash, userCheck.Data.PasswordSalt))
            {
                return new ErrorDataResult<User>("Password is wrong");
            }
            return new SuccessDataResult<User>(userCheck.Data, "Successfully login");
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
               
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                CreatedDate = DateTime.UtcNow,
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user, "Successfully registered");
        }

        public IResult UserExists(string email)
        {
            if (_userService.Exist(p => p.Email != email).Success)
            {
                return new ErrorResult("This user is valid");
            }
            return new SuccessResult();
        }
    }
}
