using Domain.Entities;

namespace Infra.Repos.Interfaces;

public interface ICityRepo
{
    public Task<bool> Create(City city);
    public Task<bool> Update(City city);
    public Task<bool> Delete(City city);
    public Task<City?> GetByName(string name);
    public Task<City?> GetById(int id);
    public Task<List<City>> GetAll();
}
