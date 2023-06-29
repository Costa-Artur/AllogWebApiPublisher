using System.ComponentModel.DataAnnotations;

namespace Univali.Api.Models;

public abstract class AuthorForManipulationDto 
{
    [Required(ErrorMessage = "You should fill out a FirstName")]
    [MaxLength(30, ErrorMessage = "The FirstName shouldn't have more than 30 characters")]
    public string FirstName { get; set; } = string.Empty;

    [Required(ErrorMessage = "You should fill out a LastName")]
    [MaxLength(30, ErrorMessage = "The LastName shouldn't have more than 30 characters")]
    public string LastName { get; set; } = string.Empty;
}