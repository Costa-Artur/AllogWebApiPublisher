using AutoMapper;
using Univali.Api.Entities;
using Univali.Api.Features.Authors.Commands.CreateAuthor;
using Univali.Api.Features.Authors.Commands.UpdateAuthor;
using Univali.Api.Features.Authors.Queries.GetAuthorDetail;
using Univali.Api.Features.Authors.Queries.GetAuthorWithCoursesDetail;
using Univali.Api.Models;


namespace Univali.Api.Profiles;

public class AuthorProfile : Profile
{
    public AuthorProfile () {
        CreateMap<Author, AuthorDto>();

        CreateMap<AuthorForUpdateDto, Author>();
        CreateMap<AuthorForCreationDto, Author>();
        CreateMap<AuthorDto, Author>();



        // CQRS
        CreateMap<Author, GetAuthorDetailDto>();
        CreateMap<Author, GetAuthorWithCoursesDetailDto>();
        CreateMap<Author, CreateAuthorDto>();
    }
}