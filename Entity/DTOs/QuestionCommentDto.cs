using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs
{
   public class QuestionCommentDto:IDto
    {
        public string Comment { get; set; }
        public string CommentingFirstName { get; set; }
        public string CommentingLastName { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
