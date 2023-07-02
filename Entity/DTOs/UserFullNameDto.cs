using Core.Entities.Abstract;

namespace Entity.DTOs
{
    public class UserFullNameDto : IDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
