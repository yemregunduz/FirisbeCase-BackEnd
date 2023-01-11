using AutoMapper;
using FirisbeCase.Application.Features.Categories.Models;
using FirisbeCase.Core.Wrappers.Paging;
using FirisbeCase.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirisbeCase.Application.Features.Categories.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreateCategoryModel, Category>().ReverseMap();
            CreateMap<CategoryListModel, IPaginate<Category>>().ReverseMap();
        }
    }
}
