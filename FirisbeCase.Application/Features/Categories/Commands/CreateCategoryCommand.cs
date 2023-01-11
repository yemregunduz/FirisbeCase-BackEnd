using AutoMapper;
using FirisbeCase.Application.Features.Categories.DependencyAggregate;
using FirisbeCase.Application.Features.Categories.Models;
using FirisbeCase.Application.Repositories;
using FirisbeCase.Core.BusinessRules;
using FirisbeCase.Core.Wrappers.Results.Abstract;
using FirisbeCase.Core.Wrappers.Results.Concrete;
using FirisbeCase.Domain.Constants;
using FirisbeCase.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirisbeCase.Application.Features.Categories.Commands
{
    public class CreateCategoryCommand : IRequest<IDataResult<Category>>
    {
        public CreateCategoryModel CreateCategoryModel { get; set; }

        public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, IDataResult<Category>>
        {
            private readonly ICategoryDependencyAggregate _categoryDependencies;

            public CreateCategoryCommandHandler(ICategoryDependencyAggregate categoryDependencies)
            {
                _categoryDependencies = categoryDependencies;
            }

            public async Task<IDataResult<Category>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
            {
                IResult result = BusinessRules.Run(
                    await _categoryDependencies.CategoryBusinessRules.CheckIfCategoryNameIsExist(request.CreateCategoryModel.Name));
                if(result != null)
                {
                    return new ErrorDataResult<Category>(result.Message);
                }
                Category category = _categoryDependencies.Mapper.Map<Category>(request.CreateCategoryModel);
                Category createdCategory = await _categoryDependencies.CategoryRepository.AddAsync(category);
                return new SuccessDataResult<Category>(createdCategory, Messages.CategoryCreated);
            }
        }
    }
}
