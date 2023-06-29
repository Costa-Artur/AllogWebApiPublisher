using MediatR;

namespace Univali.Api.Features.Courses.Commands.CreateCourse;

public class CreateCourseCommand : IRequest<CreateCourseDto> {
    public Models.CourseWithAuthorsForCreationDto Dto { get; set; } = new();
}