using Core.Entities.Abstract;
using System;

namespace Entity.DTOs
{
    public class CommentDto : IDto
    {
        public string Comment { get; set; }
        public string CommentingFirstName { get; set; }
        public string CommentingLastName { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
