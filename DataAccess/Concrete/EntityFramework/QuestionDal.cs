using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using DataContext.Concrete;
using Entity.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class QuestionDal : GenericRepository<Question>, IQuestionDal
    {
        public QuestionDal(ApplicationDbContext context) : base(context)
        {

        }
    }
}
