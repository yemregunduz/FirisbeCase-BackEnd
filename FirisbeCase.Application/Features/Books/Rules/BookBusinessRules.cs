using FirisbeCase.Application.Repositories;
using FirisbeCase.Core.Wrappers.Results.Abstract;
using FirisbeCase.Core.Wrappers.Results.Concrete;
using FirisbeCase.Domain.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirisbeCase.Application.Features.Books.Rules
{
    public class BookBusinessRules
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly ICategoryRepository _categoryRepository;
        public BookBusinessRules(IBookRepository bookRepository, IAuthorRepository authorRepository, ICategoryRepository categoryRepository)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<IResult> CheckIfBookIsAlreadyExist(string name,Guid authorId)
        {
            var response = await _bookRepository.GetSingleAsync(b=>b.Name.ToLower() == name.ToLower() && b.Author.Id == authorId);

            if(response != null)
            {
                return new ErrorResult(Messages.BookIsAlreadyExist);
            }
            return new SuccessResult();
        } 
        public async Task<IResult> CheckIfAuthorIsExist(Guid authorId)
        {
            var response = await _authorRepository.GetByIdAsync(authorId);
            if(response == null)
            {
                return new ErrorResult(Messages.AuthorIsNotFound);
            }
            return new SuccessResult();
        }
        public async Task<IResult> CheckIfCategoryIsExist(Guid categoryId)
        {
            var response = await _categoryRepository.GetByIdAsync(categoryId);
            if (response == null)
            {
                return new ErrorResult(Messages.CategoryIsNotFound);
            }
            return new SuccessResult();
        }
        public async Task<IResult> CheckIfIsbnNumberIsUnique(string isbn)
        {
            var response = await _bookRepository.GetSingleAsync(b => b.Isbn.ToLower() == isbn.ToLower());
            if (response != null)
            {
                return new ErrorResult(Messages.ABookRegisteredToIsbn);
            }
            return new SuccessResult();    
        }
    }
}
