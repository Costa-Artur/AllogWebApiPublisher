using Univali.Api.Models;


namespace Univali.Api.Features.Authors.Queries.GetAuthorWithCoursesDetail;

public class GetAuthorWithCoursesDetailDto
{
    public int AuthorId {get; set;}
    public string FirstName {get; set;} = string.Empty;
   	public string LastName {get; set;} = string.Empty;
    public ICollection<CourseDto> Courses {get;set;} = new List<CourseDto>();
}