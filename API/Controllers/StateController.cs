using App.DTOs.Countries;
using App.DTOs.States;
using App.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/state")]
[ApiController]
public class StateController : ControllerBase
{
    private readonly IStateService _stateService;

    public StateController(IStateService stateService)
    {
        _stateService = stateService;
    }

    [HttpPost("add")]
    public async Task<ActionResult<String>> Create(StateCreateUpdateDto input)
    {
        try
        {
            await _stateService.Create(input);
            return Ok("balle balle");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("update/{id}")]
    public async Task<ActionResult<String>> Update(StateCreateUpdateDto input, int id)
    {
        try
        {
            await _stateService.Update(input, id);
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
            await _stateService.Delete(id);
            return Ok("balle balle");
        }
        catch (Exception ex)
        {

            return BadRequest(ex.Message);
        }
    }

    [HttpGet("name/{name}")]
    public async Task<ActionResult<StateResponseDto>> Get(string name)
    {
        try
        {
            return Ok(await _stateService.GetByName(name));
        }
        catch (Exception ex)
        {

            return BadRequest(ex.Message);
        }
    }

    [HttpGet("id/{id}")]
    public async Task<ActionResult<StateResponseDto>> Get(int id)
    {
        try
        {
            return Ok(await _stateService.GetById(id));
        }
        catch (Exception ex)
        {

            return BadRequest(ex.Message);
        }
    }

    [HttpGet("all")]
    public async Task<ActionResult<List<StateResponseDto>>> Get()
    {
        try
        {
            return Ok(await _stateService.GetAll());
        }
        catch (Exception ex)
        {

            return BadRequest(ex.Message);
        }
    }
}
