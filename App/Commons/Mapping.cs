using App.DTOs.Cities;
using App.DTOs.Countries;
using App.DTOs.States;
using AutoMapper;
using Domain.Entities;

namespace App.Commons;

public class Mapping : Profile
{
    public Mapping()
    {
        CreateMap<CountryCreateUpdateDto, Country>();
        CreateMap<StateCreateUpdateDto, State>();
        CreateMap<CityCreateUpdateDto, City>();

        CreateMap<Country, CountryResponseDto>();
        CreateMap<State, StateResponseDto>();
        CreateMap<City, CityResponseDto>();
    }
}
