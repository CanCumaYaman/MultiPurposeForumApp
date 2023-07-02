using Core.DataAccess.Abstract;
using Core.Entities.Conrete;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IUserDal : IGenericRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
        string GetFullNameByMail(string mail);
        string GetFullNameById(int id);
    }
}
