using Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace App.DTOs.States;

public class StateCreateUpdateDto
{
    [Required]
    [StringLength(10, MinimumLength = 3)]
    public string Name { get; set; } = string.Empty;

    [Required]
    public int CountryId { get; set; }
}
