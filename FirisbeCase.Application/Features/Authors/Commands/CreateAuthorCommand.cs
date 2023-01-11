using AutoMapper;
using FirisbeCase.Application.Features.Authors.DependencyAggregate;
using FirisbeCase.Application.Features.Authors.Models;
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

namespace FirisbeCase.Application.Features.Authors.Commands
{
    public class CreateAuthorCommand : IRequest<IDataResult<Author>>
    {
        public CreateAuthorModel CreateAuthorModel { get; set; }

        public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, IDataResult<Author>>
        {
            private readonly IAuthorDependencyAggregate _authorDependencies;

            public CreateAuthorCommandHandler(IAuthorDependencyAggregate authorDependencies)
            {
                _authorDependencies = authorDependencies;
            }

            public async Task<IDataResult<Author>> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
            {
                // Aklıma yazar ile ilgili iş kuralı gelmedi :)
                IResult result = BusinessRules.Run();
                if (result != null)
                {
                    return new ErrorDataResult<Author>(result.Message);
                }
                Author author = _authorDependencies.Mapper.Map<Author>(request.CreateAuthorModel);
                Author createdAuthor = await _authorDependencies.AuthorRepository.AddAsync(author);
                return new SuccessDataResult<Author>(createdAuthor,Messages.AuthorCreated);
            }
        }
    }
}
