using Core.Entities.Abstract;
using Core.Entities.Base;
using Core.Entities.Conrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class QuestionComment:BaseEntity, IEntity
    {
        
        public string Comment { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }

    }
}
