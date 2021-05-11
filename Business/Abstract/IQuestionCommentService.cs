using Core.Utilities.Results.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
   public interface IQuestionCommentService
    {
        IDataResult<List<QuestionComment>> GetAll(Expression<Func<QuestionComment, bool>> filter = null);
        Task<List<QuestionComment>> GetAllAsync(Expression<Func<QuestionComment, bool>> filter = null);
        IDataResult<QuestionComment> Find(Expression<Func<QuestionComment, bool>> filter);
        Task<QuestionComment> FindAsync(Expression<Func<QuestionComment, bool>> filter);
        IDataResult<QuestionComment> GetById(int id);
        Task<QuestionComment> GetByIdAsync(int id);
        IResult Add(QuestionComment questionComment);
        IResult AddRange(List<QuestionComment> questionComments);
        IResult Delete(QuestionComment questionComment);
        IResult DeleteRange(List<QuestionComment> questionComments);
        IResult Update(QuestionComment questionComment);
        IResult UpdateRange(List<QuestionComment> questionComments);
        IResult Exist(Expression<Func<QuestionComment, bool>> filter);
        IDataResult<List<CommentDto>> GetAllCommentDto(int id);
    }
}
