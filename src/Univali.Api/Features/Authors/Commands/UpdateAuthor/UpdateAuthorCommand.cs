using System.ComponentModel.DataAnnotations;
using MediatR;
using Univali.Api.Models;


namespace Univali.Api.Features.Authors.Commands.UpdateAuthor;

public class UpdateAuthorCommand : IRequest<UpdateAuthorDto>
{
    public AuthorForUpdateDto Dto { get; set; } = new();
}