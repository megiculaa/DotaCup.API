using DotaCup.API.Models.Entities.Base;

namespace DotaCup.API.Models.Entities;

public class Clip : BaseEntity
{
    public string Url { get; set; }

    public int ViewCount { get; set; }

    public int LikeCount { get; set; }

    public string Description { get; set; }
}
