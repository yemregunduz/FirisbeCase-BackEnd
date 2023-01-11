using FirisbeCase.Application.Repositories;
using FirisbeCase.Core.DataAccess;
using FirisbeCase.Domain.Entities;
using FirisbeCase.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirisbeCase.Persistance.Repositories
{
    public class BookRepository : EfEntityRepositoryBase<Book, FirisbeCaseDbContext>, IBookRepository
    {
        public BookRepository(FirisbeCaseDbContext context) : base(context)
        {
        }
    }
}
