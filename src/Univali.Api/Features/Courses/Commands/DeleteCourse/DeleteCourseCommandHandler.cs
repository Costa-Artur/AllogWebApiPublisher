using AutoMapper;
using MediatR;
using Univali.Api.Repositories;

namespace Univali.Api.Features.Courses.Commands.DeleteCourse;

public class DeleteCourseCommandHandler : IRequestHandler<DeleteCourseCommand, DeleteCourseDto> {
    private readonly ICourseRepository _courseRepository;
    private readonly IMapper _mapper;

    public DeleteCourseCommandHandler(ICourseRepository courseRepository, IMapper mapper) {
        _courseRepository = courseRepository ?? throw new ArgumentNullException(nameof(courseRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }



    public async Task<DeleteCourseDto> Handle(DeleteCourseCommand request, CancellationToken cancellationToken) {
        bool success = false;

        var courseFromDatabase = await _courseRepository.GetCourseByIdAsync(request.CourseId);

        if(courseFromDatabase != null) {
            _courseRepository.RemoveCourse(courseFromDatabase);
            await _courseRepository.SaveChangesAsync();

            success = true;
        }

        return new DeleteCourseDto { Success = success };
    }
}
