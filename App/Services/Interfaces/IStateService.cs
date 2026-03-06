using App.DTOs.States;

namespace App.Services.Interfaces;

public interface IStateService
{
    public Task<bool> Create(StateCreateUpdateDto input);
    public Task<bool> Update(StateCreateUpdateDto input, int id);
    public Task<bool> Delete(int id);
    public Task<StateResponseDto?> GetByName(string name);
    public Task<StateResponseDto?> GetById(int id);
    public Task<List<StateResponseDto>> GetAll();
}
