using FirisbeCase.Core.DataAccess;
using FirisbeCase.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirisbeCase.Application.Repositories
{
    public interface IBookRepository : IEntityRepository<Book>
    {
    }
}
