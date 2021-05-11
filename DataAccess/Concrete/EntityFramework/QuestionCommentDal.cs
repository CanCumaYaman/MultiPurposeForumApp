using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using DataContext.Concrete;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
   public class QuestionCommentDal:GenericRepository<QuestionComment>,IQuestionCommentDal
    {
        private ApplicationDbContext _context;
        public QuestionCommentDal(ApplicationDbContext context):base(context)
        {
            _context = context;

        }

        public List<CommentDto> GetAllCommentDto(int id)
        {
            var result = from questionComment in _context.QuestionComments
                         join user in _context.Users
                         on questionComment.UserId equals user.Id
                         where questionComment.QuestionId == id
                         select new CommentDto()
                         {
                             Comment = questionComment.Comment,
                             CommentingFirstName = user.FirstName,
                             CommentingLastName = user.LastName,
                             CreatedDate = questionComment.CreatedDate

                         };
            return result.ToList();
        }
    }
}
