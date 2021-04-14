using Core.Entities.Abstract;

using Entity.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Concrete
{
    public class Question:BaseEntity,IEntity
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string Topic { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<QuestionComment> QuestionComments { get; set; }
    }
}
