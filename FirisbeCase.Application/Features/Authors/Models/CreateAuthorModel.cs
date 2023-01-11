using FirisbeCase.Domain.Entities;
using FirisbeCase.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirisbeCase.Application.Features.Authors.Models
{
    public class CreateAuthorModel
    {
        //public CreateAuthorModel()
        //{
        //    Books = new HashSet<Book>();
        //}
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte Age { get; set; }
        public string Country { get; set; }
        public Gender Gender { get; set; }
        //public ICollection<Book>? Books { get; set; }
    }
}
