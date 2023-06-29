using AutoMapper;
using MediatR;
using Univali.Api.Repositories;

namespace Univali.Api.Features.Courses.Queries.GetCourseWithAuthorsDetail;

public class GetCourseWithAuthorsDetailQueryHandler : IRequestHandler<GetCourseWithAuthorsDetailQuery, GetCourseWithAuthorsDetailDto>
{
    private readonly ICourseRepository _courseRepository;
    private readonly IMapper _mapper;

    public GetCourseWithAuthorsDetailQueryHandler(ICourseRepository courseRepository, IMapper mapper)
    {
        _courseRepository = courseRepository;
        _mapper = mapper;
    }

    public async Task<GetCourseWithAuthorsDetailDto> Handle(GetCourseWithAuthorsDetailQuery request, CancellationToken cancellationToken)
    {
        var courseFromDatabase = await _courseRepository.GetCourseWithAuthorsByIdAsync(request.CourseId);
        return _mapper.Map<GetCourseWithAuthorsDetailDto>(courseFromDatabase);
    }
}