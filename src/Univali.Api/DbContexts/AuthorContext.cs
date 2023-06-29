using Microsoft.EntityFrameworkCore;
using Univali.Api.Entities;

namespace Univali.Api.DbContexts;

public class AuthorContext : DbContext
{
    public DbSet<Author> Authors { get; set; } = null!;
    public DbSet<Course> Courses { get; set; } = null!;

    public AuthorContext (DbContextOptions<AuthorContext> options)
        :base (options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        var author = modelBuilder.Entity<Author>();

        author
            .HasMany(a => a.Courses)
            .WithMany(c => c.Authors)
            .UsingEntity<AuthorCourse>(
                "AuthorsCourses",
                ac => ac.Property(ac => ac.CreatedOn).HasDefaultValueSql("NOW()")
            );
        
        author
            .Property(author => author.FirstName)
            .HasMaxLength(30)
            .IsRequired();

        author
            .Property(author => author.LastName)
            .HasMaxLength(30)
            .IsRequired();

        author
            .HasData
            (
                new Author{
                    AuthorId = 1,
                    FirstName = "Stephen",
                    LastName = "King"
                },
                new Author{
                    AuthorId = 2,
                    FirstName = "George",
                    LastName = "Orwell"
                }
            );

        var course = modelBuilder.Entity<Course>();

        course
            .Property(course => course.Title)
            .HasMaxLength(60)
            .IsRequired();

        course
            .Property(course => course.Description)
            .IsRequired(false);

        course
            .Property(course => course.Price)
            .HasPrecision(5, 2);
    }
}