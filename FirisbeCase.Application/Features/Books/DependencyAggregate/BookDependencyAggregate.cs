using AutoMapper;
using FirisbeCase.Application.Features.Books.Rules;
using FirisbeCase.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirisbeCase.Application.Features.Books.DependencyAggregate
{
    public class BookDependencyAggregate : IBookDependencyAggregate
    {
        public BookDependencyAggregate(IMapper mapper, IBookRepository bookRepository, BookBusinessRules bookBusinessRules)
        {
            Mapper = mapper;
            BookRepository = bookRepository;
            BookBusinessRules = bookBusinessRules;
        }

        public IMapper Mapper { get; }
        public IBookRepository BookRepository { get; }
        public BookBusinessRules BookBusinessRules { get; }
    }
}
