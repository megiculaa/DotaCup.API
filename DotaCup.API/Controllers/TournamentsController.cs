using DotaCup.API.Data.Interfaces;
using DotaCup.API.Models.Entities;
using DotaCup.API.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace DotaCup.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TournamentsController : ControllerBase
{
    private ITournamentService _tournamentService { get; set; }

    public TournamentsController(ITournamentService tournamentService)
    {
        _tournamentService = tournamentService;
    }

    // GET: api/Tournaments
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _tournamentService.GetTournaments());
    }

    // GET: api/Tournaments/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        return Ok(await _tournamentService.GetTournament(id));
    }

    // GET: api/Tournaments/{id}/Captains
    [HttpGet("{id}/Captains")]
    public async Task<IActionResult> GetCaptains(Guid id)
    {
        return Ok(await _tournamentService.GetTournamentCapitans(id));
    }

    // POST: api/Tournaments
    [HttpPost]
    public async Task<IActionResult> Post([FromForm] CreateTournament entity)
    {
        return Ok(await _tournamentService.CreateTournament(entity));
    }

    // POST: api/Tournaments/Enter
    [HttpPost("Enter")]
    public async Task<IActionResult> Post([FromForm] EnterTournamentRequest request)
    {
        return Ok(await _tournamentService.EnterTournament(request.TournamentId, request.UserId));
    }

    // POST: api/Tournaments/SetCaptains
    [HttpPost("SetCaptains")]
    public async Task<IActionResult> Post([FromForm] SetCaptainsRequest request)
    {
        return Ok(await _tournamentService.SetCaptains(request.TournamentId, request.UserIds));
    }

    // PUT: api/Tournaments
    [HttpPut]
    public async Task<IActionResult> Put([FromForm] Tournament entity)
    {
        return Ok(await _tournamentService.UpdateTournament(entity));
    }

    // DELETE: api/Tournaments
    [HttpDelete]
    public async Task<IActionResult> Delete(Guid Id)
    {
        return Ok(await _tournamentService.DeleteTournament(Id));
    }
}
