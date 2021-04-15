using Core.Utilities.Results.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IArticleCommentService
    {
        IDataResult<List<ArticleComment>> GetAll(Expression<Func<ArticleComment, bool>> filter = null);
        Task<List<ArticleComment>> GetAllAsync(Expression<Func<ArticleComment, bool>> filter = null);
        IDataResult<ArticleComment> Find(Expression<Func<ArticleComment, bool>> filter);
        Task<ArticleComment> FindAsync(Expression<Func<ArticleComment, bool>> filter);
        IDataResult<ArticleComment> GetById(int id);
        Task<ArticleComment> GetByIdAsync(int id);
        IResult Add(ArticleComment articleComment);
        IResult AddRange(List<ArticleComment> articleComments);
        IResult Delete(ArticleComment articleComment);
        IResult DeleteRange(List<ArticleComment> articleComments);
        IResult Update(ArticleComment articleComment);
        IResult UpdateRange(List<ArticleComment> articleComments);
        IResult Exist(Expression<Func<ArticleComment, bool>> filter);
    }
}
