using AutoMapper;
using FirisbeCase.Application.Features.Categories.Rules;
using FirisbeCase.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirisbeCase.Application.Features.Categories.DependencyAggregate
{
    public class CategoryDependencyAggregate : ICategoryDependencyAggregate
    {
        public CategoryDependencyAggregate(IMapper mapper, ICategoryRepository categoryRepository, CategoryBusinessRules categoryBusinessRules)
        {
            Mapper = mapper;
            CategoryRepository = categoryRepository;
            CategoryBusinessRules = categoryBusinessRules;
        }

        public IMapper Mapper { get; }
        public ICategoryRepository CategoryRepository { get; }
        public CategoryBusinessRules CategoryBusinessRules { get; }
    }
}
