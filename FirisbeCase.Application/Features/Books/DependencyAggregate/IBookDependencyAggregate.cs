using AutoMapper;
using FirisbeCase.Application.Features.Books.Rules;
using FirisbeCase.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirisbeCase.Application.Features.Books.DependencyAggregate
{
    public interface IBookDependencyAggregate
    {
        IMapper Mapper { get; }
        IBookRepository BookRepository {get;}
        BookBusinessRules BookBusinessRules {get;}
    }
}
