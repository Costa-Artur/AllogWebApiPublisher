using System.ComponentModel.DataAnnotations;

namespace Univali.Api.Models;

public class CourseForUpdateDto : CourseForManipulationDto
{
    [Required(ErrorMessage = "You should fill out an Id")]
    public int CourseId {get; set;}

}