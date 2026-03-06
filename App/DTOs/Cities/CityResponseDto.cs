using Domain.Entities;

namespace App.DTOs.Cities;

public class CityResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public State? State { get; set; }
}
