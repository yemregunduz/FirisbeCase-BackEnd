using AutoMapper;
using FirisbeCase.Application.Features.Books.DependencyAggregate;
using FirisbeCase.Application.Features.Books.Models;
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

namespace FirisbeCase.Application.Features.Books.Commands
{
    public class CreateBookCommand : IRequest<IDataResult<Book>>
    {
        public CreateBookModel CreateBookModel { get; set; }

        public class CreateAuthorCommandHandler : IRequestHandler<CreateBookCommand, IDataResult<Book>>
        {
            private readonly IBookDependencyAggregate _bookDependencies;

            public CreateAuthorCommandHandler(IBookDependencyAggregate bookDependencies)
            {
                _bookDependencies = bookDependencies;
            }

            public async Task<IDataResult<Book>> Handle(CreateBookCommand request, CancellationToken cancellationToken)
            {
                IResult result = BusinessRules.Run(
                    await _bookDependencies.BookBusinessRules.CheckIfBookIsAlreadyExist(request.CreateBookModel.Name,request.CreateBookModel.AuthorId),
                    await _bookDependencies.BookBusinessRules.CheckIfAuthorIsExist(request.CreateBookModel.AuthorId),
                    await _bookDependencies.BookBusinessRules.CheckIfCategoryIsExist(request.CreateBookModel.CategoryId),
                    await _bookDependencies.BookBusinessRules.CheckIfIsbnNumberIsUnique(request.CreateBookModel.Isbn)
                    );
                if(result != null)
                {
                    return new ErrorDataResult<Book>(result.Message);
                }
                Book book = _bookDependencies.Mapper.Map<Book>(request.CreateBookModel);
                Book createdBook = await _bookDependencies.BookRepository.AddAsync(book);
                return new SuccessDataResult<Book>(createdBook, Messages.BookCreated);
            }
        }
    }
}
