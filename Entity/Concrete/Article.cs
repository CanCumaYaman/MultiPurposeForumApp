using Core.Entities.Abstract;
using Core.Entities.Base;
using Core.Entities.Conrete;
using System.Collections.Generic;

namespace Entity.Concrete
{
    public class Article:BaseEntity,IEntity
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string Topic { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<ArticleComment> ArticleComments { get; set; }
    }
}
