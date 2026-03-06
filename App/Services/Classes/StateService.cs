using App.Commons;
using App.DTOs.States;
using App.Services.Interfaces;
using AutoMapper;
using Domain.Entities;
using Infra.Repos.Interfaces;

namespace App.Services.Classes;

public class StateService : IStateService
{
    private readonly IStateRepo _stateRepo;
    private readonly ICountryRepo _countryRepo;
    private readonly IMapper _mapper;
    public StateService(IStateRepo stateRepo, ICountryRepo countryRepo, IMapper mapper)
    {
        _stateRepo = stateRepo;
        _countryRepo = countryRepo;
        _mapper = mapper;
    }

    public async Task<bool> Create(StateCreateUpdateDto input)
    {
        var stateExists = await _stateRepo.GetByName(input.Name) != null;
        if(stateExists)
            throw new BadRequestException($"{input.Name.ToLower()} is already exists in database");

        var countryExists = await _countryRepo.GetById(input.CountryId) == null;
        if (countryExists)
            throw new BadRequestException($"Country with id: {input.CountryId} doesn't exists");

        State state = _mapper.Map<State>(input);
        var result = await _stateRepo.Create(state);

        if (!result)
            throw new BadRequestException($"failed to create {input.Name.ToLower()} as State");

        return true;
    }

    public async Task<bool> Update(StateCreateUpdateDto input, int id)
    {
        var state = await _stateRepo.GetById(id);
        if (state == null)
            throw new BadRequestException($"State with id: {id} doesn't exists");

        var stateExists = await _stateRepo.GetByName(input.Name);
        if (stateExists != null && stateExists.Id != id)
            throw new BadRequestException($"{input.Name.ToLower()} is already exists in database");

        _mapper.Map(input, state);

        var result = await _stateRepo.Update(state);

        if (!result)
            throw new BadRequestException($"failed to update");

        return true;
    }

    public async Task<bool> Delete(int id)
    {
        var state = await _stateRepo.GetById(id);
        if (state == null)
            throw new BadRequestException($"ellle...");

        var result = await _stateRepo.Delete(state);

        if (!result)
            throw new BadRequestException("failed to delete");

        return true;
    }

    public async Task<StateResponseDto?> GetByName(string name)
    {
        var state = await _stateRepo.GetByName(name);
        if(state == null)
            throw new BadRequestException($"elle...");

        return _mapper.Map<StateResponseDto>(state);
    }

    public async Task<StateResponseDto?> GetById(int id)
    {
        var state = await _stateRepo.GetById(id);
        if (state == null)
            throw new BadRequestException($"State with id: {id} doesn't exists");

        return _mapper.Map<StateResponseDto>(state);
    }

    public async Task<List<StateResponseDto>> GetAll()
    {
        var states = await _stateRepo.GetAll();

        if (!states.Any())
            throw new BadRequestException($"ellle...");

        return _mapper.Map<List<StateResponseDto>>(states);
    }
}
