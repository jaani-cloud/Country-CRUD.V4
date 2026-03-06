using System.ComponentModel.DataAnnotations;

namespace App.DTOs.Cities;

public class CityCreateUpdateDto
{
    [Required]
    [StringLength(100 , MinimumLength = 3)]
    public string Name { get; set; } = string.Empty;
    [Required]
    public int StateId { get; set; }
}
