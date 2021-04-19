using Core.DataAccess.Abstract;
using Core.Entities.Conrete;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
   public  interface IUserDal: IGenericRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
    }
}
