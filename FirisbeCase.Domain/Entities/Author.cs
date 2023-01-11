using FirisbeCase.Core.Entities;
using FirisbeCase.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FirisbeCase.Domain.Entities
{
    public class Author : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [NotMapped]
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
        public byte Age { get; set; }
        public string Country { get; set; }
        public Gender Gender { get; set; }
        public ICollection<Book>? Books { get; set; }

    }
}
