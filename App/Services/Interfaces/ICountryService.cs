using App.DTOs.Countries;

namespace App.Services.Interfaces;

public interface ICountryService
{
    public Task<bool> Create(CountryCreateUpdateDto input);
    public Task<bool> Update(CountryCreateUpdateDto input, int id);
    public Task<bool> Delete(int id);
    public Task<CountryResponseDto?> GetByName(string name);
    public Task<CountryResponseDto?> GetById(int id);
    public Task<List<CountryResponseDto>> GetAll();
}
