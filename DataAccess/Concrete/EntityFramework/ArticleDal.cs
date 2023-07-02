using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using DataContext.Concrete;
using Entity.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class ArticleDal : GenericRepository<Article>, IArticleDal
    {
        public ArticleDal(ApplicationDbContext context) : base(context)
        {

        }
    }
}
