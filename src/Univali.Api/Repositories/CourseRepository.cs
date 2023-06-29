using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Univali.Api.DbContexts;
using Univali.Api.Entities;
using Univali.Api.Models;

namespace Univali.Api.Repositories;

public class CourseRepository : ICourseRepository {
    private readonly AuthorContext _context;
    private readonly IMapper _mapper;

    public CourseRepository(AuthorContext context, IMapper mapper) {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    

    public async Task<Course?> GetCourseByIdAsync(int courseId) {
        return await _context.Courses
            .FirstOrDefaultAsync(c => c.CourseId == courseId);
    }

    public async Task<Course?> GetCourseWithAuthorsByIdAsync(int courseId) {
        return await _context.Courses
            .Include(c => c.Authors)
            .FirstOrDefaultAsync(c => c.CourseId == courseId);
    }

    public void AddCourse(Course course) {
        _context.Courses.Add(course);
    }

    public void UpdateCourse(Course course, CourseForUpdateDto courseForUpdateDto) {
        _mapper.Map(courseForUpdateDto, course);
    }

    public void RemoveCourse(Course course) {
        _context.Courses.Remove(course);
    }

    

    public async Task<List <Author>> GetAuthorsAsync(List<int> authors) {
        var authorsFromDatabase = await _context.Authors
            .Where(a => authors.Contains(a.AuthorId))
            .ToListAsync();

        return authorsFromDatabase;
    }



    public async Task<bool> SaveChangesAsync() {
        return await _context.SaveChangesAsync() > 0;
    }
}
