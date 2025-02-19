using AutoMapper;
using DotaCup.API.Data.Interfaces;
using DotaCup.API.Models.Entities;
using DotaCup.API.Models.Requests;
using DotaCup.API.Models.Responses;
using DotaCup.API.Models.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace DotaCup.API.Services;

public class TournamentService : ITournamentService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IMapper _mapper;

    public TournamentService(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _userManager = userManager;
        _mapper = mapper;
    }

    public async Task<TournamentViewModel> GetTournament(Guid Id)
    {
        return _mapper.Map<TournamentViewModel>(await _unitOfWork.TournamentRepository.GetByID(Id, x => x.Members));
    }

    public async Task<IEnumerable<Tournament>> GetTournaments()
    {
        return await _unitOfWork.TournamentRepository.Get();
    }

    public async Task<IEnumerable<Guid>> GetTournamentCapitans(Guid id)
    {
        return (await _unitOfWork.TournamentRepository
            .Get(x => x.Id == id)).FirstOrDefault().Captains;
    }

    public async Task<IEnumerable<Guid>> GetTournamentMembers(Guid id)
    {
        return (await _unitOfWork.TournamentRepository
            .Get(x => x.Id == id, includeProperties: x => x.Members))
            .FirstOrDefault()
                .Members.Select(x => Guid.Parse(x.Id));
    }

    public async Task<BaseResponse> CreateTournament(CreateTournament entity)
    {
        try
        {
            var tournament = new Tournament
            {
                Id = Guid.NewGuid(),
                ImgUrl = entity.ImgUrl,
                Description = entity.Description,
                AdditionalInfo = entity.AdditionalInfo,
                StartDate = DateTime.SpecifyKind(entity.StartDate, DateTimeKind.Utc),
                CreatedDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc),
            };

            await _unitOfWork.TournamentRepository.Insert(tournament);
            await _unitOfWork.Save();

            return BaseResponse.Succeed(tournament.Id);
        }
        catch (Exception ex)
        {
            return BaseResponse.Failed(ex.Message);
        }
    }

    public async Task<BaseResponse> UpdateTournament(Tournament entity)
    {
        try
        {
            await _unitOfWork.TournamentRepository.Update(entity);
            await _unitOfWork.Save();

            return BaseResponse.Succeed();
        }
        catch (Exception ex)
        {
            return BaseResponse.Failed(ex.Message);
        }
    }

    public async Task<BaseResponse> DeleteTournament(Guid Id)
    {
        try
        {
            var entity = await _unitOfWork.TournamentRepository.GetByID(Id);
            entity.IsDeleted = true;
            await _unitOfWork.Save();

            return BaseResponse.Succeed();
        }
        catch (Exception ex)
        {
            return BaseResponse.Failed(ex.Message);
        }
    }

    public async Task<BaseResponse> EnterTournament(Guid tournamentId, Guid userId)
    {
        try
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            if (user == null)
            {
                return BaseResponse.Failed("User not found.");
            }

            var tournament = await _unitOfWork.TournamentRepository.GetByID(tournamentId, x => x.Members);

            if (tournament == null || tournament.IsDeleted)
            {
                return BaseResponse.Failed("Tournament not found.");
            }

            if (tournament!.Members.Contains(user))
            {
                return BaseResponse.Failed("User is already participating.");
            }

            tournament!.Members.Add(user);

            await _unitOfWork.TournamentRepository.Update(tournament);
            await _unitOfWork.Save();

            return BaseResponse.Succeed();
        }
        catch (Exception ex)
        {
            return BaseResponse.Failed(ex.Message);
        }
    }

    public async Task<BaseResponse> SetCaptains(Guid tournamentId, List<Guid> userIds)
    {
        try
        {
            foreach (var userId in userIds)
            {
                var user = await _userManager.FindByIdAsync(userId.ToString());

                if (user == null)
                {
                    return BaseResponse.Failed($"User id: {userId} - not found.");
                }
            }

            var tournament = await _unitOfWork.TournamentRepository.GetByID(tournamentId, x => x.Members);

            if (tournament == null || tournament.IsDeleted)
            {
                return BaseResponse.Failed("Tournament not found.");
            }

            foreach (var userId in userIds)
            {
                if (tournament!.Captains.Contains(userId))
                {
                    return BaseResponse.Failed("User is already captain.");
                }

                if (tournament!.Members.Count == 0 || !tournament!.Members.Select(x => x.Id).Contains(userId.ToString()))
                {
                    return BaseResponse.Failed("User(s) is not participating.");
                }

                tournament!.Captains.Add(userId);
            }

            await _unitOfWork.TournamentRepository.Update(tournament);
            await _unitOfWork.Save();

            return BaseResponse.Succeed();
        }
        catch (Exception ex)
        {
            return BaseResponse.Failed(ex.Message);
        }
    }
}
