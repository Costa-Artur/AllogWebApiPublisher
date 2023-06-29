using MediatR;
using Univali.Api.Models;

namespace Univali.Api.Features.Publishers.UpdatePublisher;

public class UpdatePublisherCommand : IRequest<UpdatePublisherDto>
{
    public PublisherForUpdateDto Dto { get; set; } = new ();
}