using DotaCup.API.Models.Entities;
using DotaCup.API.Models.Requests;
using DotaCup.API.Models.Responses;
using DotaCup.API.Models.ViewModels;

namespace DotaCup.API.Data.Interfaces;

public interface ITournamentService
{
    Task<BaseResponse> CreateTournament(CreateTournament entity);
    Task<TournamentViewModel> GetTournament(Guid Id);
    Task<IEnumerable<Guid>> GetTournamentCapitans(Guid id);
    Task<IEnumerable<Guid>> GetTournamentMembers(Guid id);
    Task<IEnumerable<Tournament>> GetTournaments();
    Task<BaseResponse> UpdateTournament(Tournament entity);
    Task<BaseResponse> DeleteTournament(Guid Id);
    Task<BaseResponse> EnterTournament(Guid tournamentId, Guid userId);
    Task<BaseResponse> SetCaptains(Guid tournamentId, List<Guid> userIds);
}
