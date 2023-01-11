using AutoMapper;
using FirisbeCase.Application.Features.Authors.Models;
using FirisbeCase.Core.Wrappers.Paging;
using FirisbeCase.Domain.Entities;

namespace FirisbeCase.Application.Features.Authors.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreateAuthorModel, Author>().ReverseMap();
            CreateMap<AuthorListModel, IPaginate<Author>>().ReverseMap();
        }
    }
}
