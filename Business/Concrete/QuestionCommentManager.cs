using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
  public  class QuestionCommentManager:IQuestionCommentService
    {
        IQuestionCommentDal _questionCommentDal;

        public QuestionCommentManager(IQuestionCommentDal questionCommentDal)
        {
            _questionCommentDal = questionCommentDal;
        }
        public IResult Add(QuestionComment questionComment)
        {

            _questionCommentDal.Add(questionComment);
            return new SuccessResult("Your Comment successfully posted");
        }

        public IResult AddRange(List<QuestionComment> questionComments)
        {
            _questionCommentDal.AddRange(questionComments);
            return new SuccessResult("Comments successfully posted");
        }

        public IResult Delete(QuestionComment questionComment)
        {
            _questionCommentDal.Delete(questionComment);
            return new SuccessResult("Your Comment successfull deleted");
        }

        public IResult DeleteRange(List<QuestionComment> questionComments)
        {
            _questionCommentDal.DeleteRange(questionComments);
            return new SuccessResult("Comments successfully deleted");
        }

        public IResult Exist(Expression<Func<QuestionComment, bool>> filter)
        {
            if (_questionCommentDal.Exist(filter))
            {
                return new SuccessResult("This comment exist");
            }
            return new ErrorResult("This comment is not registered");
        }

        public IDataResult<QuestionComment> Find(Expression<Func<QuestionComment, bool>> filter)
        {
            return new SuccessDataResult<QuestionComment>(_questionCommentDal.Find(filter));
        }

        public Task<QuestionComment> FindAsync(Expression<Func<QuestionComment, bool>> filter)
        {
            return _questionCommentDal.FindAsync(filter);
        }

        public IDataResult<List<QuestionComment>> GetAll(Expression<Func<QuestionComment, bool>> filter = null)
        {
            return new SuccessDataResult<List<QuestionComment>>(_questionCommentDal.GetAll(filter));
        }

        public Task<List<QuestionComment>> GetAllAsync(Expression<Func<QuestionComment, bool>> filter = null)
        {
            return _questionCommentDal.GetAllAsync(filter);
        }

        public IDataResult<QuestionComment> GetById(int id)
        {
            return new SuccessDataResult<QuestionComment>(_questionCommentDal.GetById(id));
        }

        public Task<QuestionComment> GetByIdAsync(int id)
        {
            return _questionCommentDal.GetByIdAsync(id);
        }

        public IResult Update(QuestionComment questionComment)
        {
            _questionCommentDal.Update(questionComment);
            return new SuccessResult("Comment successfully updated");
        }

        public IResult UpdateRange(List<QuestionComment> questionComments)
        {
            _questionCommentDal.UpdateRange(questionComments);
            return new SuccessResult("Comments successfully updated");
        }
    }
}
