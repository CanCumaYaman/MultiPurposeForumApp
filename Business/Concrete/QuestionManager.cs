using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Validation;
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
    public class QuestionManager : IQuestionService
    {
        IQuestionDal _questionDal;
        public QuestionManager(IQuestionDal questionDal)
        {
            _questionDal = questionDal;
        }
        public QuestionManager()
        {

        }

        [ValidationAspect(typeof(QuestionValidator))]
        [CacheRemoveAspect("IQuestionService.Get")]
        public IResult Add(Question question)
        {
            var result = _questionDal.Find(p => p.Title == question.Title);
            if (result != null)
            {
                return new ErrorResult("This Question already added");
            }
           
            _questionDal.Add(question);
            return new SuccessResult("Your Question successfully posted");
        }

        public IResult AddRange(List<Question> questions)
        {
            _questionDal.AddRange(questions);
            return new SuccessResult("Questions successfully posted");
        }

        public IResult Delete(Question question)
        {
            _questionDal.Delete(question);
            return new SuccessResult("Your Question successfull deleted");
        }

        public IResult DeleteRange(List<Question> questions)
        {
            _questionDal.DeleteRange(questions);
            return new SuccessResult("Questions successfully deleted");
        }

        public IResult Exist(Expression<Func<Question, bool>> filter)
        {
            if (_questionDal.Exist(filter))
            {
                return new SuccessResult("This Question exist");
            }
            return new ErrorResult("This Question is not registered");
        }

        public IDataResult<Question> Find(Expression<Func<Question, bool>> filter)
        {
            return new SuccessDataResult<Question>(_questionDal.Find(filter));
        }

        public Task<Question> FindAsync(Expression<Func<Question, bool>> filter)
        {
            return _questionDal.FindAsync(filter);
        }

        [LogAspect]
        [CacheAspect]
        public IDataResult<List<Question>> GetAll(Expression<Func<Question, bool>> filter = null)
        {
            return new SuccessDataResult<List<Question>>(_questionDal.GetAll(filter));
        }

        public Task<List<Question>> GetAllAsync(Expression<Func<Question, bool>> filter = null)
        {
            return _questionDal.GetAllAsync(filter);
        }

        public IDataResult<Question> GetById(int id)
        {
            return new SuccessDataResult<Question>(_questionDal.GetById(id));
        }

        public Task<Question> GetByIdAsync(int id)
        {
            return _questionDal.GetByIdAsync(id);
        }

        public IResult Update(Question question)
        {
            var updatedQuestion = new Question
            {
                Title = question.Title,
                Body = question.Body,
                Topic = question.Topic,
                CreatedDate = question.CreatedDate,
                UpdatedDate=DateTime.UtcNow,
                UserId = question.UserId,

            };
            _questionDal.Update(updatedQuestion);
            return new SuccessResult("Question successfully updated");
        }

        public IResult UpdateRange(List<Question> Questions)
        {
            _questionDal.UpdateRange(Questions);
            return new SuccessResult("Questions successfully updated");
        }

    }
}
