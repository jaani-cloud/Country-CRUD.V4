using Domain.Entities;

namespace App.DTOs.States;

public class StateResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Country? Country { get; set; }
}
