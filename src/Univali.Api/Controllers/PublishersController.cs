using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Univali.Api.Features.Publishers.CreatePublisher;
using Univali.Api.Features.Publishers.UpdatePublisher;
using Univali.Api.Models;

namespace Univali.Api.Controllers;

[Route("api/publishers")]
[Authorize]
public class PublishersController : MainController
{
    private readonly IMediator _mediator;

    public PublishersController(IMediator mediator) {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    [HttpPost]
    public async Task<ActionResult<PublisherDto>> CreatePublisher (
        PublisherForCreationDto publisherForCreationDto
    )
    {
        var createPublisherCommand = new CreatePublisherCommand {Dto = publisherForCreationDto};
        var publisherToReturn = await _mediator.Send(createPublisherCommand);

        // return CreatedAtRoute
        // (
        //     "GetPublisherById",
        //     new { publisherId = publisherToReturn.PublisherId },
        //     publisherToReturn
        // );

        return Ok(publisherToReturn);   
    }

    [HttpPut("{publisherId}")]
    public async Task<ActionResult> UpdatePublisher (
        int publisherId,
        PublisherForUpdateDto publisherForUpdateDto
    )
    {
        if(publisherForUpdateDto.PublisherId != publisherId) return BadRequest();
        var updatePublisherCommand = new UpdatePublisherCommand {Dto = publisherForUpdateDto};
        var updatePublisher = await _mediator.Send(updatePublisherCommand);

        if(updatePublisher.Success == false) return NotFound();

        return NoContent();
    }
}