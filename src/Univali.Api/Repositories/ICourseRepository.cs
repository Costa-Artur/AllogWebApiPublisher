using Microsoft.AspNetCore.JsonPatch;
using Univali.Api.Entities;
using Univali.Api.Models;

namespace Univali.Api.Repositories;

public interface ICourseRepository {
    // COURSE GET
    Task<Course?> GetCourseByIdAsync(int courseId); 
    Task<Course?> GetCourseWithAuthorsByIdAsync(int courseId); 

    // COURSE POST
    void AddCourse(Course course);

    // COURSE PUT
    void UpdateCourse(Course course, CourseForUpdateDto courseForUpdateDto);

    // COURSE DELETE
    void RemoveCourse(Course course);



    // UTILS
    Task<List <Author>> GetAuthorsAsync(List<int> authors);



    // CONTEXT COMMIT
    Task<bool> SaveChangesAsync();
}