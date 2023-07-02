using System;

namespace Core.Entities.Base
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public BaseEntity()
        {
            this.CreatedDate = DateTime.UtcNow;
        }
    }
}
