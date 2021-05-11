using Core.DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
   public interface IQuestionCommentDal:IGenericRepository<QuestionComment>
    {
        List<CommentDto> GetAllCommentDto(int id);
    }
}
