using AutoMapper;
using MediatR;
using Univali.Api.Repositories;

namespace Univali.Api.Features.Courses.Queries.GetCourseDetail;

public class GetCourseDetailQueryHandler : IRequestHandler<GetCourseDetailQuery, GetCourseDetailDto>
{
    private readonly ICourseRepository _courseRepository;
    private readonly IMapper _mapper;

    public GetCourseDetailQueryHandler(ICourseRepository courseRepository, IMapper mapper)
    {
        _courseRepository = courseRepository;
        _mapper = mapper;
    }

    public async Task<GetCourseDetailDto> Handle(GetCourseDetailQuery request, CancellationToken cancellationToken)
    {
        var courseFromDatabase = await _courseRepository.GetCourseByIdAsync(request.CourseId);
        return _mapper.Map<GetCourseDetailDto>(courseFromDatabase);
    }
}