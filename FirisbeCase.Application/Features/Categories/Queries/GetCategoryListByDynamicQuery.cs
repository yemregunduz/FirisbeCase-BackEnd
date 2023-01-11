using FirisbeCase.Application.Features.Categories.DependencyAggregate;
using FirisbeCase.Application.Features.Categories.Models;
using FirisbeCase.Core.DynamicQuery;
using FirisbeCase.Core.Requests;
using FirisbeCase.Core.Wrappers.Paging;
using FirisbeCase.Core.Wrappers.Results.Abstract;
using FirisbeCase.Core.Wrappers.Results.Concrete;
using FirisbeCase.Domain.Constants;
using FirisbeCase.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FirisbeCase.Application.Features.Categories.Queries
{
    public class GetCategoryListByDynamicQuery : IRequest<IDataResult<CategoryListModel>>
    {
        public ListRequestParameter ListRequestParameter { get; set; }
        public Dynamic Dynamic { get; set; }

        public class GetCategoryListByDynamicQueryHandler : IRequestHandler<GetCategoryListByDynamicQuery, IDataResult<CategoryListModel>>
        {
            private readonly ICategoryDependencyAggregate _categoryDependencies;

            public GetCategoryListByDynamicQueryHandler(ICategoryDependencyAggregate categoryDependencies)
            {
                _categoryDependencies = categoryDependencies;
            }

            public async Task<IDataResult<CategoryListModel>> Handle(GetCategoryListByDynamicQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Category> categories = await _categoryDependencies.CategoryRepository.
                    GetListByDynamicAsync(dynamic: request.Dynamic, index: request.ListRequestParameter.Page,
                    size: request.ListRequestParameter.PageSize, include: m => m.Include(c=>c.Books),
                    cancellationToken: cancellationToken);
                CategoryListModel categoryListModel = _categoryDependencies.Mapper.Map<CategoryListModel>(categories);
                return new SuccessDataResult<CategoryListModel>(categoryListModel, Messages.CategoriesListed);
            }
        }
    }
}
