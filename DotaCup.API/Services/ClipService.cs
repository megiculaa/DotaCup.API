using DotaCup.API.Data.Interfaces;
using DotaCup.API.Models.Entities;
using DotaCup.API.Models.Responses;

namespace DotaCup.API.Services;

public class ClipService : IClipService
{
    private readonly IUnitOfWork _unitOfWork;

    public ClipService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Clip> GetClip(Guid Id)
    {
        return await _unitOfWork.ClipRepository.GetByID(Id);
    }

    public async Task<IEnumerable<Clip>> GetClips()
    {
        return await _unitOfWork.ClipRepository.Get();
    }

    public async Task<BaseResponse> DeleteClip(Guid Id)
    {
        try
        {
            var clip = await _unitOfWork.ClipRepository.GetByID(Id);

            if (clip == null)
            {
                return BaseResponse.Failed("Clip not found.");
            }

            clip.IsDeleted = true;

            await _unitOfWork.ClipRepository.Update(clip);
            await _unitOfWork.Save();

            return BaseResponse.Succeed();
        }
        catch (Exception ex)
        {
            return BaseResponse.Failed(ex.Message);
        }
    }

    public async Task<BaseResponse> AddView(Guid Id)
    {
        try
        {
            var clip = await _unitOfWork.ClipRepository.GetByID(Id);

            if (clip == null)
            {
                return BaseResponse.Failed("Clip not found.");
            }

            clip.ViewCount++;

            await _unitOfWork.ClipRepository.Update(clip);
            await _unitOfWork.Save();

            return BaseResponse.Succeed();
        }
        catch (Exception ex)
        {
            return BaseResponse.Failed(ex.Message);
        }
    }

    public async Task<BaseResponse> AddLike(Guid Id)
    {
        try
        {
            var clip = await _unitOfWork.ClipRepository.GetByID(Id);

            if (clip == null)
            {
                return BaseResponse.Failed("Clip not found.");
            }

            clip.LikeCount++;

            await _unitOfWork.ClipRepository.Update(clip);
            await _unitOfWork.Save();

            return BaseResponse.Succeed();
        }
        catch (Exception ex)
        {
            return BaseResponse.Failed(ex.Message);
        }
    }
}
