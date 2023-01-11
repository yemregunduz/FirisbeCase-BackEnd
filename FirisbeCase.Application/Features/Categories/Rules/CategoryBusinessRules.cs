using FirisbeCase.Application.Repositories;
using FirisbeCase.Core.Wrappers.Results.Abstract;
using FirisbeCase.Core.Wrappers.Results.Concrete;
using FirisbeCase.Domain.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirisbeCase.Application.Features.Categories.Rules
{
    public class CategoryBusinessRules
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryBusinessRules(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<IResult> CheckIfCategoryNameIsExist(string categoryName)
        {
            var result = await _categoryRepository.GetSingleAsync(c => c.Name == categoryName);
            if(result != null)
            {
                return new ErrorResult(Messages.CategoryAlreadyExist);
            }
            return new SuccessResult();
        }
    }
}
