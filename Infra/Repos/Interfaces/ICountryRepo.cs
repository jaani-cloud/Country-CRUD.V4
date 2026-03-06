using Domain.Entities;

namespace Infra.Repos.Interfaces;

public interface ICountryRepo
{
    public Task<bool> Create(Country country);
    public Task<bool> Update(Country country);
    public Task<bool> Delete(Country country);
    public Task<Country?> GetByName(string name);
    public Task<Country?> GetById(int id);
    public Task<List<Country>> GetAll();
}
