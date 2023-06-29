using AutoMapper;
using MediatR;
using Univali.Api.Entities;
using Univali.Api.Models;
using Univali.Api.Repositories;

namespace Univali.Api.Features.Courses.Commands.CreateCourse;

public class CreateCustomerCommandHandler : IRequestHandler<CreateCourseCommand, CreateCourseDto> {
    private readonly ICourseRepository _courseRepository;
    private readonly IMapper _mapper;

    public CreateCustomerCommandHandler(ICourseRepository courseRepository, IMapper mapper) {
        _courseRepository = courseRepository ?? throw new ArgumentNullException(nameof(courseRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }



    public async Task<CreateCourseDto> Handle(CreateCourseCommand request, CancellationToken cancellationToken) {
        List<int> authorIds = request.Dto.Authors
            .Select(a => a.AuthorId)
            .ToList();

        var courseWithoutAuthorsDto = _mapper.Map<CourseForCreationDto>(request.Dto);
        var newCourse = _mapper.Map<Course>(courseWithoutAuthorsDto);
        newCourse.Authors = await _courseRepository.GetAuthorsAsync(authorIds);

        _courseRepository.AddCourse(newCourse);
        await _courseRepository.SaveChangesAsync();

        var courseToReturn = _mapper.Map<CreateCourseDto>(newCourse);
        
        return courseToReturn;
    }
}