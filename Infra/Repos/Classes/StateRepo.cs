using Domain.Entities;
using Infra.Data;
using Infra.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repos.Classes;

public class StateRepo : IStateRepo
{
    private readonly DataContext _context;

    public StateRepo(DataContext context)
    {
        _context = context;
    }

    public async Task<bool> Create(State state)
    {
        _context.States.Add(state);
        var result = await _context.SaveChangesAsync();
        return result > 0;
    }
    public async Task<bool> Update(State state)
    {
        _context.States.Update(state);
        var result = await _context.SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> Delete(State state)
    {
        _context.States.Remove(state);
        var result = await _context.SaveChangesAsync();
        return result > 0;
    }

    public async Task<State?> GetByName(string name) =>
        await _context.States.AsNoTracking().Include(s => s.Country).FirstOrDefaultAsync(s => s.Name == name);

    public async Task<State?> GetById(int id) =>
        await _context.States.Include(s => s.Country).FirstOrDefaultAsync(s => s.Id == id);

    public async Task<List<State>> GetAll() =>
        await _context.States.AsNoTracking().Include(s => s.Country).ToListAsync();
}
