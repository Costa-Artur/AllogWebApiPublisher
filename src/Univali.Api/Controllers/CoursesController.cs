using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Univali.Api.DbContexts;
using Univali.Api.Features.Courses.Commands.CreateCourse;
using Univali.Api.Features.Courses.Commands.DeleteCourse;
using Univali.Api.Features.Courses.Commands.UpdateCourse;
using Univali.Api.Features.Courses.Queries.GetCourseDetail;
using Univali.Api.Features.Courses.Queries.GetCourseWithAuthorsDetail;
using Univali.Api.Models;
using Univali.Api.Repositories;

namespace Univali.Api.Controllers;

[Route("api/courses")]
[Authorize]
public class CoursesController : MainController {
    private readonly IMediator _mediator;

    public CoursesController(IMediator mediator) {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }



    [HttpGet("{courseId}", Name = "GetCourseById")]
    public async Task<ActionResult <GetCourseDetailDto>> GetCourseById(int courseId) {
        var getCourseDetailQuery = new GetCourseDetailQuery { CourseId = courseId };
        var courseToReturn = await _mediator.Send(getCourseDetailQuery);

        return courseToReturn != null ? Ok(courseToReturn) : NotFound();
    }

    [HttpGet("with-authors/{courseId}", Name = "GetCourseWithAuthorsById")]
    public async Task<ActionResult <GetCourseDetailDto>> GetCourseWithAuthorsById(int courseId) {
        var getCourseWithAuthorsDetailQuery = new GetCourseWithAuthorsDetailQuery { CourseId = courseId };
        var courseToReturn = await _mediator.Send(getCourseWithAuthorsDetailQuery);

        return courseToReturn != null ? Ok(courseToReturn) : NotFound();
    }

    [HttpPost]
    public async Task<ActionResult <CreateCourseDto>> CreateCourse(CourseWithAuthorsForCreationDto courseForCreationDto) {
        var createCourseCommand = new CreateCourseCommand { Dto = courseForCreationDto };
        var courseToReturn = await _mediator.Send(createCourseCommand);

        return courseToReturn != null ? 
        CreatedAtRoute(
            "GetCourseWithAuthorsById",
            new { courseId = courseToReturn.CourseId },
            courseToReturn
        ) :
        BadRequest();
    }

    [HttpPut("{courseId}")]
    public async Task<ActionResult> UpdateCourse(int courseId, CourseForUpdateDto courseForUpdateDto) {
        if(courseForUpdateDto.CourseId != courseId) return BadRequest();

        var updateCourseCommand = new UpdateCourseCommand { Dto = courseForUpdateDto };
        var result = await _mediator.Send(updateCourseCommand);

        return result.Success ? NoContent() : NotFound();
    }

    [HttpDelete("{courseId}")]
    public async Task<ActionResult> DeleteCourse(int courseId) {
        var deleteCourseCommand = new DeleteCourseCommand { CourseId = courseId };
        var result = await _mediator.Send(deleteCourseCommand);

        return result.Success ? NoContent() : NotFound();
    }
}
