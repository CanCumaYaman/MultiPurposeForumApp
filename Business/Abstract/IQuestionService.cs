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
   public interface IQuestionService
    {
        IDataResult<List<Question>> GetAll(Expression<Func<Question, bool>> filter = null);
        Task<List<Question>> GetAllAsync(Expression<Func<Question, bool>> filter = null);
         IDataResult<Question> Find(Expression<Func<Question, bool>> filter);
        Task<Question> FindAsync(Expression<Func<Question, bool>> filter);
         IDataResult<Question> GetById(int id);
        Task<Question> GetByIdAsync(int id);
        IResult Add(Question question);
        IResult AddRange(List<Question> questions);
        IResult Delete(Question question);
        IResult DeleteRange(List<Question> questions);
        IResult Update(Question question);
        IResult UpdateRange(List<Question> questions);
        IResult Exist(Expression<Func<Question, bool>> filter);
    }
}
