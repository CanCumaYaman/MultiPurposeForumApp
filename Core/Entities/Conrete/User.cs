using Core.Entities.Abstract;
using Core.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities.Conrete
{
    public class User : BaseEntity, IEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        [MaxLength(500)]
        public byte[] PasswordSalt { get; set; }
        [MaxLength(500)]
        public byte[] PasswordHash { get; set; }
        public string FullName => $"{FirstName} {LastName}";




    }
}
