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
   public class ArticleCommentDal:GenericRepository<ArticleComment>,IArticleCommentDal
    {
        private ApplicationDbContext _context;
        public ArticleCommentDal(ApplicationDbContext context):base(context)
        {
            _context = context;
        }
        public List<CommentDto> GetAllCommentDto(int id)
        {
            var result = from articleComment in _context.ArticleComments
                         join user in _context.Users
                         on articleComment.UserId equals user.Id
                         where articleComment.ArticleId == id
                         select new CommentDto()
                         {
                             Comment = articleComment.Comment,
                             CommentingFirstName = user.FirstName,
                             CommentingLastName = user.LastName,
                             CreatedDate = articleComment.CreatedDate

                         };
            return result.ToList();
        }
    }
}
