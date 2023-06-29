using MediatR;
using Univali.Api.Models;


namespace Univali.Api.Features.Authors.Commands.CreateAuthor;

public class CreateAuthorCommand : IRequest<CreateAuthorDto>
{
    public AuthorForCreationDto Dto { get; set; } = new();
}