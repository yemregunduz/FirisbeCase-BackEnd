using FirisbeCase.Application.Features.Authors.DependencyAggregate;
using FirisbeCase.Application.Features.Authors.Models;
using FirisbeCase.Core.DynamicQuery;
using FirisbeCase.Core.Requests;
using FirisbeCase.Core.Wrappers.Paging;
using FirisbeCase.Core.Wrappers.Results.Abstract;
using FirisbeCase.Core.Wrappers.Results.Concrete;
using FirisbeCase.Domain.Constants;
using FirisbeCase.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirisbeCase.Application.Features.Authors.Queries
{
    public class GetAuthorListByDynamicQuery : IRequest<IDataResult<AuthorListModel>>
    {
        public ListRequestParameter ListRequestParameter { get; set; }
        public Dynamic Dynamic { get; set; }

        public class GetAuthorListByDynamicQueryHandler : IRequestHandler<GetAuthorListByDynamicQuery, IDataResult<AuthorListModel>>
        {
            private readonly IAuthorDependencyAggregate _authorDependencies;

            public GetAuthorListByDynamicQueryHandler(IAuthorDependencyAggregate categoryDependencies)
            {
                _authorDependencies = categoryDependencies;
            }

            public async Task<IDataResult<AuthorListModel>> Handle(GetAuthorListByDynamicQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Author> categories = await _authorDependencies.AuthorRepository.
                    GetListByDynamicAsync(dynamic: request.Dynamic, index: request.ListRequestParameter.Page,
                    size: request.ListRequestParameter.PageSize, include: m => m.Include(c => c.Books),
                    cancellationToken: cancellationToken);
                AuthorListModel authorListModel = _authorDependencies.Mapper.Map<AuthorListModel>(categories);
                return new SuccessDataResult<AuthorListModel>(authorListModel, Messages.AuthorsListed);
            }
        }
    }
}
