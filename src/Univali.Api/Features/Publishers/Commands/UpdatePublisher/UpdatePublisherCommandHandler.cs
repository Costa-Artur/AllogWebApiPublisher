using AutoMapper;
using MediatR;
using Univali.Api.Repositories;

namespace Univali.Api.Features.Publishers.UpdatePublisher;

public class UpdatePublisherCommandHandler : IRequestHandler<UpdatePublisherCommand, UpdatePublisherDto>
{
    private readonly IPublisherRepository _publisherRepository;
    private readonly IMapper _mapper;

    public UpdatePublisherCommandHandler(IPublisherRepository publisherRepository, IMapper mapper)
    {
        _publisherRepository = publisherRepository;
        _mapper = mapper;
    }
    public async Task<UpdatePublisherDto> Handle(UpdatePublisherCommand request, CancellationToken cancellationToken)
    {
        var publisherFromDatabase = await _publisherRepository.GetPublisherByIdAsync(request.Dto.PublisherId);
        if(publisherFromDatabase == null)
        {
            return new UpdatePublisherDto {Success = false};
        }
        _mapper.Map(request.Dto, publisherFromDatabase);

        await _publisherRepository.SaveChangesAsync();

        return new UpdatePublisherDto {Success = true};
    }
}