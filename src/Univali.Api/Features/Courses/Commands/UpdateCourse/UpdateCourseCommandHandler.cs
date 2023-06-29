using AutoMapper;
using MediatR;
using Univali.Api.Repositories;

namespace Univali.Api.Features.Courses.Commands.UpdateCourse;

public class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommand, UpdateCourseDto>
{
    private readonly ICourseRepository _courseRepository;
    private readonly IMapper _mapper;

    public UpdateCourseCommandHandler(ICourseRepository courseRepository, IMapper mapper) {
        _courseRepository = courseRepository ?? throw new ArgumentNullException(nameof(courseRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<UpdateCourseDto> Handle(UpdateCourseCommand request, CancellationToken cancellationToken) {
        bool success = false;

        var courseFromDatabase = await _courseRepository.GetCourseByIdAsync(request.Dto.CourseId);

        if(courseFromDatabase != null) {
            _courseRepository.UpdateCourse(courseFromDatabase, request.Dto);
            await _courseRepository.SaveChangesAsync();

            success = true;
        }

        return new UpdateCourseDto { Success = success };
    }
}