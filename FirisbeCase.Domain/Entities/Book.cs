using FirisbeCase.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirisbeCase.Domain.Entities
{
    public class Book:BaseEntity
    {
        public string Name { get; set; }
        public string Isbn { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public Guid AuthorId { get; set; }
        public Author Author { get; set; }
    }
}

