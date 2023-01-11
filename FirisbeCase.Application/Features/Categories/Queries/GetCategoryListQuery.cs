using AutoMapper;
using FirisbeCase.Application.Features.Categories.DependencyAggregate;
using FirisbeCase.Application.Features.Categories.Models;
using FirisbeCase.Application.Repositories;
using FirisbeCase.Core.Requests;
using FirisbeCase.Core.Wrappers.Paging;
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

namespace FirisbeCase.Application.Features.Categories.Queries
{
    public class GetCategoryListQuery : IRequest<IDataResult<CategoryListModel>>
    {
        public ListRequestParameter ListRequestParameter { get; set; }

        public class GetCategoryListQueryHandler : IRequestHandler<GetCategoryListQuery, IDataResult <CategoryListModel>>
        {
            private readonly ICategoryDependencyAggregate _categoryDependencies;

            public GetCategoryListQueryHandler(ICategoryDependencyAggregate categoryDependencies)
            {
                _categoryDependencies = categoryDependencies;
            }

            public async Task<IDataResult<CategoryListModel>> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Category> categories = await _categoryDependencies.CategoryRepository.GetListAsync(
                    index:request.ListRequestParameter.Page, size:request.ListRequestParameter.PageSize,cancellationToken: cancellationToken);
                CategoryListModel categoryListModel = _categoryDependencies.Mapper.Map<CategoryListModel>(categories);
                return new SuccessDataResult<CategoryListModel>(categoryListModel,Messages.CategoriesListed);

            }
        }
    }
}
