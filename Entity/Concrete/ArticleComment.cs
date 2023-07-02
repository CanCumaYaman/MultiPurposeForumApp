using Core.Entities.Abstract;
using Core.Entities.Base;
using Core.Entities.Conrete;

namespace Entity.Concrete
{
    public class ArticleComment : BaseEntity, IEntity
    {
        public string Comment { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int ArticleId { get; set; }
        public Article Article { get; set; }
    }
}
