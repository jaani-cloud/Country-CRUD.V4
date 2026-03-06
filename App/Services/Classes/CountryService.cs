using App.Commons;
using App.DTOs.Countries;
using App.Services.Interfaces;
using AutoMapper;
using Domain.Entities;
using Infra.Repos.Interfaces;

namespace App.Services.Classes;

public class CountryService : ICountryService
{
    private readonly ICountryRepo _countryRepo;
    private readonly IMapper _mapper;
    public CountryService(ICountryRepo countryRepo, IMapper mapper)
    {
        _countryRepo = countryRepo;
        _mapper = mapper;
    }

    public async Task<bool> Create(CountryCreateUpdateDto input)
    {
        var exists = await _countryRepo.GetByName(input.Name) == null;
        if (!exists)
            throw new BadRequestException("Country already exists");

        Country country = _mapper.Map<Country>(input);
        var result = await _countryRepo.Create(country);

        if (!result)
            throw new BadRequestException("Failed to create country");

        return true;

    }
    public async Task<bool> Update(CountryCreateUpdateDto input, int id)
    {
        var country = await _countryRepo.GetById(id);

        if (country == null)
            throw new BadRequestException($"Country with id: {id} doesn't exists");

        var countryExists = await _countryRepo.GetByName(input.Name);
        if (countryExists != null && id != countryExists.Id)
            throw new BadRequestException($"{countryExists.Name} is already exists at id: {countryExists.Id}");

        _mapper.Map(input, country);
        var result = await _countryRepo.Update(country);

        if (!result)
            throw new BadRequestException("Country update failed");



        return true;
    }

    public async Task<bool> Delete(int id)
    {
        var country = await _countryRepo.GetById(id);

        if (country == null)
            throw new BadRequestException($"Country with id: {id} doesn't exists");

        var result = await _countryRepo.Delete(country);

        if (!result)
            throw new BadRequestException("Country delete failed");

        return true;
    }

    public async Task<CountryResponseDto?> GetByName(string name)
    {
        var country = await _countryRepo.GetByName(name);

        if (country == null)
            throw new BadRequestException($"Country with name: {name} does't exists");

        return _mapper.Map<CountryResponseDto>(country);
    }

    public async Task<CountryResponseDto?> GetById(int id)
    {
        var country = await _countryRepo.GetById(id);

        if (country == null)
            throw new BadRequestException($"Country with id: {id} doesn't exists");

        return _mapper.Map<CountryResponseDto>(country);
    }

    public async Task<List<CountryResponseDto>> GetAll()
    {
        var countries = await _countryRepo.GetAll();

        if (!countries.Any())
            throw new BadRequestException("🤨 Pahle create to karle...");

        return _mapper.Map<List<CountryResponseDto>>(countries);
    }
}
