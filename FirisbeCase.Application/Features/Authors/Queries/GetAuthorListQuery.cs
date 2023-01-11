using AutoMapper;
using FirisbeCase.Application.Features.Authors.DependencyAggregate;
using FirisbeCase.Application.Features.Authors.Models;
using FirisbeCase.Application.Repositories;
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
    public class GetAuthorListQuery : IRequest<IDataResult<AuthorListModel>>
    {
        public ListRequestParameter ListRequestParameter { get; set; }

        public class GetAuthorListQueryHandler : IRequestHandler<GetAuthorListQuery, IDataResult<AuthorListModel>>
        {
            private readonly IAuthorDependencyAggregate _authorDependencies;

            public GetAuthorListQueryHandler(IAuthorDependencyAggregate authorDependencies)
            {
                _authorDependencies = authorDependencies;
            }

            public async Task<IDataResult<AuthorListModel>> Handle(GetAuthorListQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Author> authors = await _authorDependencies.AuthorRepository.GetListAsync(
                    index: request.ListRequestParameter.Page, size: request.ListRequestParameter.PageSize, include: m => m.Include(a => a.Books), 
                    cancellationToken: cancellationToken);
                AuthorListModel authorListModel = _authorDependencies.Mapper.Map<AuthorListModel>(authors);
                return new SuccessDataResult<AuthorListModel>(authorListModel, Messages.AuthorsListed);
            }
        }

    }
}
