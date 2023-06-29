using System.ComponentModel.DataAnnotations;

namespace Univali.Api.Models;

public class AuthorForUpdateDto : AuthorForManipulationDto
{
    [Required(ErrorMessage = "You should fill out an Id")]
    public int AuthorId {get; set;}

}