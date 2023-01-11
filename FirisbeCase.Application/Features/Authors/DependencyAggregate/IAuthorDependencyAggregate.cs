using AutoMapper;
using FirisbeCase.Application.Features.Authors.Rules;
using FirisbeCase.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirisbeCase.Application.Features.Authors.DependencyAggregate
{
    public interface IAuthorDependencyAggregate
    {
        public IMapper Mapper { get;}
        public IAuthorRepository AuthorRepository { get; }
        public AuthorBusinessRules AuthorBusinessRules { get;}
    }
}
