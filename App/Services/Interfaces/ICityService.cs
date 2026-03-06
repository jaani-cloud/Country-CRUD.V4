using App.DTOs.Cities;

namespace App.Services.Interfaces;

public interface ICityService
{
    public Task<bool> Create(CityCreateUpdateDto input);
    public Task<bool> Update(CityCreateUpdateDto input, int id);
    public Task<bool> Delete(int id);
    public Task<CityResponseDto?> GetByName(string name);
    public Task<CityResponseDto?> GetById(int id);
    public Task<List<CityResponseDto>> GetAll();
}
