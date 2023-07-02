using Core.Entities.Abstract;
using Core.Entities.Base;

namespace Core.Entities.Conrete
{
    public class OperationClaim : BaseEntity, IEntity
    {
        public string Name { get; set; }
    }
}
