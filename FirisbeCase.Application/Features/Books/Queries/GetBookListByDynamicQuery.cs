using AutoMapper;
using FirisbeCase.Application.Features.Books.DependencyAggregate;
using FirisbeCase.Application.Features.Books.Models;
using FirisbeCase.Core.DynamicQuery;
using FirisbeCase.Core.Requests;
using FirisbeCase.Core.Wrappers.Paging;
using FirisbeCase.Core.Wrappers.Results.Abstract;
using FirisbeCase.Core.Wrappers.Results.Concrete;
using FirisbeCase.Domain.Constants;
using FirisbeCase.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FirisbeCase.Application.Features.Books.Queries
{
    public class GetBookListByDynamicQuery : IRequest<IDataResult<BookListModel>>
    {
        public ListRequestParameter ListRequestParameter { get; set; }
        public Dynamic  Dynamic { get; set; }

        public class GetBookListByDynamicQueryHandler : IRequestHandler<GetBookListByDynamicQuery, IDataResult<BookListModel>>
        {
            private readonly IBookDependencyAggregate _bookDependencies;

            public GetBookListByDynamicQueryHandler(IBookDependencyAggregate bookDependencies)
            {
                _bookDependencies = bookDependencies;
            }

            public async Task<IDataResult<BookListModel>> Handle(GetBookListByDynamicQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Book> books = await _bookDependencies.BookRepository.GetListByDynamicAsync(dynamic:request.Dynamic,index: request.ListRequestParameter.Page,
                    size: request.ListRequestParameter.PageSize, include: m => m.Include(b => b.Author).Include(b => b.Category),
                    cancellationToken: cancellationToken);
                BookListModel bookListModel = _bookDependencies.Mapper.Map<BookListModel>(books);
                return new SuccessDataResult<BookListModel>(bookListModel, Messages.BooksListed);
            }
        }
    }
}
