using Core.Entities.Abstract;

using Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entity.Concrete
{
   public class User:BaseEntity,IEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        [MaxLength(500)]
        public byte[] PasswordSalt { get; set; }
        [MaxLength(500)]
        public byte[] PasswordHash { get; set; }
        public ICollection<Article> Articles { get; set; }
        public ICollection<Question> Questions { get; set; }
        public ICollection<ArticleComment> ArticleComments { get; set; }
        public ICollection<QuestionComment> QuestionComments { get; set; }
    }
}
