using Core.DataAccess.Concrete.EntityFramework;
using Core.Entities.Conrete;
using DataAccess.Abstract;
using DataContext.Concrete;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class UserDal : GenericRepository<User>,IUserDal
    {
        private ApplicationDbContext _context;
        public UserDal(ApplicationDbContext context):base(context)
        {
            _context = context;

        }
       
        public List<OperationClaim> GetClaims(User user)
        {
            
                var result = from operationClaim in _context.OperationClaims
                             join userOperationClaim in _context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();

            
        }
    }
}
