using DotaCup.API.Models.Entities;
using DotaCup.API.Models.Responses;

namespace DotaCup.API.Data.Interfaces;

public interface IClipService
{
    Task<BaseResponse> AddLike(Guid Id);
    Task<BaseResponse> AddView(Guid Id);
    Task<BaseResponse> DeleteClip(Guid Id);
    Task<Clip> GetClip(Guid Id);
    Task<IEnumerable<Clip>> GetClips();
}
