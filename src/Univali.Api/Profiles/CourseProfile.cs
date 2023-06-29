using AutoMapper;

using Univali.Api.Entities;
using Univali.Api.Models;

using Univali.Api.Features.Courses.Queries.GetCourseDetail;
using Univali.Api.Features.Courses.Commands.CreateCourse;
using Univali.Api.Features.Courses.Queries.GetCourseWithAuthorsDetail;

namespace Univali.Api.Profiles;

public class CourseProfile : Profile {
    public CourseProfile() {
        CreateMap<Course, CourseDto>();

        CreateMap<CourseForUpdateDto, Course>();
        CreateMap<CourseForCreationDto, Course>();
        CreateMap<CourseDto, Course>();

        CreateMap<CourseWithAuthorsForCreationDto, CourseForCreationDto>();



        // CQRS
        CreateMap<Course, GetCourseDetailDto>();
        CreateMap<Course, GetCourseWithAuthorsDetailDto>();
        CreateMap<Course, CreateCourseDto>();
    }
}
