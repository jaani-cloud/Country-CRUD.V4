using Domain.Entities;
using Infra.Data;
using Infra.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repos.Classes;

public class CityRepo : ICityRepo
{
    private readonly DataContext _context;
    public CityRepo(DataContext context)
    {
        _context = context;
    }

    public async Task<bool> Create(City city)
    {
        _context.Cities.Add(city);
        var result = await _context.SaveChangesAsync();
        return result > 0;
    }
    public async Task<bool> Update(City city)
    {
        _context.Cities.Update(city);
        var result = await _context.SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> Delete(City city)
    {
        _context.Cities.Remove(city);
        var result = await _context.SaveChangesAsync();
        return result > 0;
    }

    public async Task<City?> GetByName(string name) => 
        await _context.Cities.AsNoTracking().Include(c => c.State).ThenInclude(s => s.Country).FirstOrDefaultAsync(c => c.Name == name);
    public async Task<City?> GetById(int id) =>
        await _context.Cities.Include(c => c.State).ThenInclude(s => s.Country).FirstOrDefaultAsync(c => c.Id == id);
    public async Task<List<City>> GetAll() =>
        await _context.Cities.AsNoTracking().Include(c => c.State).ThenInclude(s => s.Country).ToListAsync();
}
