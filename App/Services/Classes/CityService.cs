using App.Commons;
using App.DTOs.Cities;
using App.Services.Interfaces;
using AutoMapper;
using Domain.Entities;
using Infra.Repos.Interfaces;

namespace App.Services.Classes;

public class CityService : ICityService
{
    private readonly ICityRepo _cityRepo;
    private readonly IStateRepo _stateRepo;
    private readonly IMapper _mapper;

    public CityService(ICityRepo cityRepo, IStateRepo stateRepo, IMapper mapper)
    {
        _cityRepo = cityRepo;
        _stateRepo = stateRepo;
        _mapper = mapper;
    }

    public async Task<bool> Create(CityCreateUpdateDto input)
    {
        var cityExists = await _cityRepo.GetByName(input.Name);
        if (cityExists != null)
            throw new BadRequestException($"{input.Name.ToLower()} already exists at id: {cityExists.Id}");

        var stateExists = await _stateRepo.GetById(input.StateId);
        if (stateExists == null)
            throw new BadRequestException($"StateId: {input.StateId} elle..");

        City city = _mapper.Map<City>(input);
        var result = await _cityRepo.Create(city);

        if (!result)
            throw new BadRequestException("failed to crate");

        return true;
    }

    public async Task<bool> Update(CityCreateUpdateDto input, int id)
    {
        var city = await _cityRepo.GetById(id);
        if(city == null)
            throw new BadRequestException("city: ellee...");

        var state = await _stateRepo.GetById(input.StateId);
        if (state == null)
            throw new BadRequestException("state: ellee..");

        var cityExists = await _cityRepo.GetByName(input.Name);
        if (cityExists != null && id != cityExists.Id)
            throw new BadRequestException($"{cityExists.Name} is already exists at id: {cityExists.Id}");

        var result = await _cityRepo.Update(city);
        if (!result)
            throw new BadRequestException("failed to update");

        return true;

    }

    public async Task<bool> Delete(int id)
    {
        var city = await _cityRepo.GetById(id);

        if (city == null)
            throw new BadRequestException("city: elle...");

        var result = await _cityRepo.Delete(city);
        if (!result)
            throw new BadRequestException("failed to delete");

        return true;
    }

    public async Task<CityResponseDto?> GetByName(string name)
    {
        var city = await _cityRepo.GetByName(name);
        if (city == null)
            throw new BadRequestException("city: elleee...");

        return _mapper.Map<CityResponseDto>(city);
    }

    public async Task<CityResponseDto?> GetById(int id)
    {
        var city = await _cityRepo.GetById(id);
        if(city == null)
            throw new BadRequestException($"city ellle...");

        return _mapper.Map<CityResponseDto>(city);
    }

    public async Task<List<CityResponseDto>> GetAll()
    {
        var cities = await _cityRepo.GetAll();
        if (!cities.Any())
            throw new BadRequestException("data: elleee...");

        return _mapper.Map<List<CityResponseDto>>(cities);
    }
}
