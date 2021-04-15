using Core.Entities.Abstract;
using Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Conrete
{
   public class UserOperationClaim: BaseEntity, IEntity
    {
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
    }
}
