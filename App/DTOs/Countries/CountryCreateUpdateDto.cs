using System.ComponentModel.DataAnnotations;

namespace App.DTOs.Countries;

public class CountryCreateUpdateDto
{
    [Required]
    [StringLength(30, MinimumLength = 3)]
    public string Name { get; set; } = string.Empty;
}
