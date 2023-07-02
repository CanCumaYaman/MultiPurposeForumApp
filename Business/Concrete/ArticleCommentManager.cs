using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ArticleCommentManager : IArticleCommentService
    {
        private readonly IArticleCommentDal _articleCommentDal;

        public ArticleCommentManager(IArticleCommentDal articleCommentDal)
        {
            _articleCommentDal = articleCommentDal;
        }
        public IResult Add(ArticleComment articleComment)
        {

            _articleCommentDal.Add(articleComment);
            return new SuccessResult("Your Comment successfully posted");
        }

        public IResult AddRange(List<ArticleComment> articleComments)
        {
            _articleCommentDal.AddRange(articleComments);
            return new SuccessResult("Comments successfully posted");
        }

        public IResult Delete(ArticleComment articleComment)
        {
            _articleCommentDal.Delete(articleComment);
            return new SuccessResult("Your Comment successfull deleted");
        }

        public IResult DeleteRange(List<ArticleComment> articleComments)
        {
            _articleCommentDal.DeleteRange(articleComments);
            return new SuccessResult("Comments successfully deleted");
        }

        public IResult Exist(Expression<Func<ArticleComment, bool>> filter)
        {
            if (_articleCommentDal.Exist(filter))
            {
                return new SuccessResult("This comment exist");
            }
            return new ErrorResult("This comment is not registered");
        }

        public IDataResult<ArticleComment> Find(Expression<Func<ArticleComment, bool>> filter)
        {
            return new SuccessDataResult<ArticleComment>(_articleCommentDal.Find(filter));
        }

        public Task<ArticleComment> FindAsync(Expression<Func<ArticleComment, bool>> filter)
        {
            return _articleCommentDal.FindAsync(filter);
        }

        public IDataResult<List<ArticleComment>> GetAll(Expression<Func<ArticleComment, bool>> filter = null)
        {
            return new SuccessDataResult<List<ArticleComment>>(_articleCommentDal.GetAll(filter));
        }

        public Task<List<ArticleComment>> GetAllAsync(Expression<Func<ArticleComment, bool>> filter = null)
        {
            return _articleCommentDal.GetAllAsync(filter);
        }

        public IDataResult<List<CommentDto>> GetAllCommentDto(int id)
        {
            return new SuccessDataResult<List<CommentDto>>(_articleCommentDal.GetAllCommentDto(id));
        }

        public IDataResult<ArticleComment> GetById(int id)
        {
            return new SuccessDataResult<ArticleComment>(_articleCommentDal.GetById(id));
        }

        public Task<ArticleComment> GetByIdAsync(int id)
        {
            return _articleCommentDal.GetByIdAsync(id);
        }

        public IResult Update(ArticleComment articleComment)
        {
            _articleCommentDal.Update(articleComment);
            return new SuccessResult("Comment successfully updated");
        }

        public IResult UpdateRange(List<ArticleComment> articleComments)
        {
            _articleCommentDal.UpdateRange(articleComments);
            return new SuccessResult("Comments successfully updated");
        }
    }
}
