using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Univali.Api.DbContexts;
using Univali.Api.Entities;
using Univali.Api.Models;

namespace Univali.Api.Repositories;

public class PublisherRepository : IPublisherRepository
{
    private readonly PublisherContext _context;
    private readonly IMapper _mapper;

    public PublisherRepository(PublisherContext publisherContext, IMapper mapper)
    {
        _context = publisherContext;
        _mapper = mapper;
    }

    //Course Repository

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

    //Author Repository

    public async Task<List <Author>> GetAuthorsAsync(List<int> authors) {
        var authorsFromDatabase = await _context.Authors
            .Where(a => authors.Contains(a.AuthorId))
            .ToListAsync();

        return authorsFromDatabase;
    }

    public async Task<bool> SaveChangesAsync() {
        return await _context.SaveChangesAsync() > 0;
    }

    public void AddAuthor (Author author)
    {
        _context.Add(author);
    }

    public void DeleteAuthor(int authorId)
    {
        var authorFromDatabase = _context.Authors.FirstOrDefault(a => a.AuthorId == authorId);
        if (authorFromDatabase != null)
            _context.Authors.Remove(authorFromDatabase!);
    }

    public async Task<Author?> GetAuthorByIdAsync(int authorId)
    {
        return await _context.Authors.FirstOrDefaultAsync(a => a.AuthorId == authorId);
    }

    public async Task<Author?> GetAuthorWithCoursesByIdAsync(int authorId)
    {
        return await _context.Authors.Include(a => a.Courses).FirstOrDefaultAsync(a => a.AuthorId == authorId);
    }

    public async Task<bool> AuthorExistsAsync(int authorId)
    {
        return await _context.Authors.AnyAsync(a => a.AuthorId == authorId);
    }

    //Publisher Repository
    public void AddPublisher(Publisher publisher)
    {
        _context.Add(publisher);
    }

    public async Task<Publisher?> GetPublisherByIdAsync(int publisherId)
    {
        return await _context.Publishers.FirstOrDefaultAsync(p => p.PublisherId == publisherId);
    }
}