using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs
{
    public class UserFullNameDto : IDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
