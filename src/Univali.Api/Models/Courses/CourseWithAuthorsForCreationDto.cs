namespace Univali.Api.Models;

public class CourseWithAuthorsForCreationDto : CourseForManipulationDto {
    public List<AuthorDto> Authors { get; set; } = new();
}

