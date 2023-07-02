using Core.DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IArticleCommentDal : IGenericRepository<ArticleComment>
    {
        List<CommentDto> GetAllCommentDto(int id);
    }
}
