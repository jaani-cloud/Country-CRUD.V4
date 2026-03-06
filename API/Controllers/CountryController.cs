using App.DTOs.Countries;
using App.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/country")]
[ApiController]
public class CountryController : ControllerBase
{
    private readonly ICountryService _countryService;

    public CountryController(ICountryService countryService)
    {
        _countryService = countryService;
    }

    [HttpPost("add")]
    public async Task<ActionResult<String>> Create(CountryCreateUpdateDto input)
    {
        try
        {
            await _countryService.Create(input);
            return Ok("balle balle");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("update/{id}")]
    public async Task<ActionResult<String>> Update(CountryCreateUpdateDto input, int id)
    {
        try
        {
            await _countryService.Update(input, id);
            return Ok("balle balle");
        }
        catch (Exception ex)
        {

            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("delete/{id}")]
    public async Task<ActionResult<string>> Delete(int id)
    {
        try
        {
            await _countryService.Delete(id);
            return Ok("balle balle");
        }
        catch (Exception ex)
        {

            return BadRequest(ex.Message);
        }
    }

    [HttpGet("name/{name}")]
    public async Task<ActionResult<CountryResponseDto>> Get(string name)
    {
        try
        {
            return Ok(await _countryService.GetByName(name));
        }
        catch (Exception ex)
        {

            return BadRequest(ex.Message);
        }
    }

    [HttpGet("id/{id}")]
    public async Task<ActionResult<CountryResponseDto>> Get(int id)
    {
        try
        {
            return Ok(await _countryService.GetById(id));
        }
        catch (Exception ex)
        {

            return BadRequest(ex.Message);
        }
    }

    [HttpGet("all")]
    public async Task<ActionResult<List<CountryResponseDto>>> Get()
    {
        try
        {
            return Ok(await _countryService.GetAll());
        }
        catch (Exception ex)
        {

            return BadRequest(ex.Message);
        }
    }
}
