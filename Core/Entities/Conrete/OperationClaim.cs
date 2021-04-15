using Core.Entities.Abstract;
using Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Conrete
{
   public class OperationClaim: BaseEntity, IEntity
    {
       
        public string Name { get; set; }
    }
}
