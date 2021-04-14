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
    public class ArticleManager : IArticleService
    {
        IArticleDal _articleDal;

        public ArticleManager(IArticleDal articleDal)
        {
            _articleDal = articleDal;
        }
        public IResult Add(Article article)
        {
            var result = _articleDal.Find(p => p.Title == article.Title);
            if (result != null)
            {
                return new ErrorResult("This Article already added");
            }
            _articleDal.Add(article);
            return new SuccessResult("Your Article successfully posted");
        }

        public IResult AddRange(List<Article> articles)
        {
            _articleDal.AddRange(articles);
            return new SuccessResult("Articles successfully posted");
        }

        public IResult Delete(Article article)
        {
            _articleDal.Delete(article);
            return new SuccessResult("Your Article successfull deleted");
        }

        public IResult DeleteRange(List<Article> articles)
        {
            _articleDal.DeleteRange(articles);
            return new SuccessResult("Articles successfully deleted");
        }

        public IResult Exist(Expression<Func<Article, bool>> filter)
        {
            if (_articleDal.Exist(filter))
            {
                return new SuccessResult("This article exist");
            }
            return new ErrorResult("This article is not registered");
        }

        public IDataResult<Article> Find(Expression<Func<Article, bool>> filter)
        {
            return new SuccessDataResult<Article>(_articleDal.Find(filter));
        }

        public Task<Article> FindAsync(Expression<Func<Article, bool>> filter)
        {
            return _articleDal.FindAsync(filter);
        }

        public IDataResult<List<Article>> GetAll(Expression<Func<Article, bool>> filter = null)
        {
            return new SuccessDataResult<List<Article>>(_articleDal.GetAll(filter));
        }

        public Task<List<Article>> GetAllAsync(Expression<Func<Article, bool>> filter = null)
        {
            return _articleDal.GetAllAsync(filter);
        }

        public IDataResult<Article> GetById(int id)
        {
            return new SuccessDataResult<Article>(_articleDal.GetById(id));
        }

        public Task<Article> GetByIdAsync(int id)
        {
            return _articleDal.GetByIdAsync(id);
        }

        public IResult Update(Article article)
        {
            _articleDal.Update(article);
            return new SuccessResult("Article successfully updated");
        }

        public IResult UpdateRange(List<Article> articles)
        {
            _articleDal.UpdateRange(articles);
            return new SuccessResult("Articles successfully updated");
        }

       
    }
}
