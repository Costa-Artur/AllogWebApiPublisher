using MediatR;
using Univali.Api.Models;

namespace Univali.Api.Features.Publishers.CreatePublisher;

public class CreatePublisherCommand : IRequest<CreatePublisherDto>
{
    public PublisherForCreationDto Dto {get;set;} = new ();
}