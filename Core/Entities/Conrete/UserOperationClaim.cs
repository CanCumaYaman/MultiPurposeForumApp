using Core.Entities.Abstract;
using Core.Entities.Base;

namespace Core.Entities.Conrete
{
    public class UserOperationClaim : BaseEntity, IEntity
    {
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
    }
}
