using FirisbeCase.Core.Wrappers.Paging;
using FirisbeCase.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirisbeCase.Application.Features.Authors.Models
{
    public class AuthorListModel : BasePageableModel
    {
        public IList<Author> Items { get; set; }
    }
}
