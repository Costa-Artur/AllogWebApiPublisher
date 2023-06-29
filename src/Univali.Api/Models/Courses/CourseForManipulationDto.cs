using System.ComponentModel.DataAnnotations;

namespace Univali.Api.Models;

public abstract class CourseForManipulationDto {
    [Required(ErrorMessage = "You should fill out a Title")]
    [MaxLength(60, ErrorMessage = "The Title shouldn't have more than 60 characters")]
    public string Title { get; set; } = string.Empty;
    
    public string Description { get; set; } = string.Empty;

    [Required(ErrorMessage = "You should fill out a Price")]
    // TODO: validacao de Precision(5, 2)
    public decimal Price { get; set; }
}