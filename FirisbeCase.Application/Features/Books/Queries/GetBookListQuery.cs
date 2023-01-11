using FirisbeCase.Application.Features.Books.DependencyAggregate;
using FirisbeCase.Application.Features.Books.Models;
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

namespace FirisbeCase.Application.Features.Books.Queries
{
    public class GetBookListQuery : IRequest<IDataResult<BookListModel>>
    {
        public ListRequestParameter ListRequestParameter { get; set; }

        public class GetBookListQueryHandler : IRequestHandler<GetBookListQuery, IDataResult<BookListModel>>
        {
            private readonly IBookDependencyAggregate _bookDependencies;

            public GetBookListQueryHandler(IBookDependencyAggregate bookDependencies)
            {
                _bookDependencies = bookDependencies;
            }


            public async Task<IDataResult<BookListModel>> Handle(GetBookListQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Book> books = await _bookDependencies.BookRepository.GetListAsync(index: request.ListRequestParameter.Page,
                    size: request.ListRequestParameter.PageSize, include: m=>m.Include(b => b.Author).Include(b=>b.Category),
                    cancellationToken: cancellationToken);
                BookListModel bookListModel = _bookDependencies.Mapper.Map<BookListModel>(books);
                return new SuccessDataResult<BookListModel>(bookListModel, Messages.BooksListed);
            }
        }
    }
}
