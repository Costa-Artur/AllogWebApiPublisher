using Microsoft.EntityFrameworkCore;
using Univali.Api.Entities;

namespace Univali.Api.DbContexts;

public class PublisherContext : DbContext
{
    public DbSet<Publisher> Publishers {get;set;} = null!;
    public DbSet<Course> Courses {get;set;} = null!;
    public DbSet<Author> Authors {get;set;} = null!;

    public PublisherContext(DbContextOptions<PublisherContext> options)
    : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        var publisher = modelBuilder.Entity<Publisher>();

        publisher
            .HasMany(p => p.Courses);
        
        publisher
            .Property(p => p.FirstName)
            .HasMaxLength(30)
            .IsRequired();

        publisher
            .Property(p => p.LastName)
            .HasMaxLength(30)
            .IsRequired();

        publisher
            .Property(p => p.Cpf)
            .IsRequired();

        publisher
            .HasData(   
                new Publisher("Publisher", "Teste", "1234567890")
                {
                    PublisherId = 1
                },
                new Publisher("Publisher", "Teste2", "1234567890")
                {
                    PublisherId = 2
                }
            );

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