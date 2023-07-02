using Core.Utilities.Results.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IArticleService
    {
        IDataResult<List<Article>> GetAll(Expression<Func<Article, bool>> filter = null);
        Task<List<Article>> GetAllAsync(Expression<Func<Article, bool>> filter = null);
        IDataResult<Article> Find(Expression<Func<Article, bool>> filter);
        Task<Article> FindAsync(Expression<Func<Article, bool>> filter);
        IDataResult<Article> GetById(int id);
        Task<Article> GetByIdAsync(int id);
        IResult Add(Article article);
        IResult AddRange(List<Article> articles);
        IResult Delete(Article article);
        IResult DeleteRange(List<Article> articles);
        IResult Update(Article article);
        IResult UpdateRange(List<Article> articles);
        IResult Exist(Expression<Func<Article, bool>> filter);
    }
}
