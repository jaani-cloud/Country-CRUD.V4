using Domain.Entities;
using Infra.Data;
using Infra.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repos.Classes;

public class CountryRepo : ICountryRepo
{
    private readonly DataContext _context;

    public CountryRepo(DataContext context)
    {
        _context = context;
    }

    public async Task<bool> Create(Country country)
    {
        _context.Countries.Add(country);
        var result = await _context.SaveChangesAsync();
        return result > 0;
    }
    public async Task<bool> Update(Country country)
    {
        _context.Countries.Update(country);
        var result = await _context.SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> Delete(Country country)
    {
        _context.Countries.Remove(country);
        var result = await _context.SaveChangesAsync();
        return result > 0;
    }

    public async Task<Country?> GetByName(string name) =>
        await _context.Countries.AsNoTracking().FirstOrDefaultAsync(c => c.Name == name);

    public async Task<Country?> GetById(int id) => 
        await _context.Countries.FindAsync(id);

    public async Task<List<Country>> GetAll() =>
        await _context.Countries.AsNoTracking().ToListAsync();
}
