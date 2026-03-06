using Domain.Entities;

namespace Infra.Repos.Interfaces;

public interface IStateRepo
{
    public Task<bool> Create(State state);
    public Task<bool> Update(State state);
    public Task<bool> Delete(State state);
    public Task<State?> GetByName(string name);
    public Task<State?> GetById(int id);
    public Task<List<State>> GetAll();
}
