namespace DotaCup.API.Models.Entities.Base;

public abstract class BaseEntity
{
    public Guid Id { get; set; }
    public bool IsDeleted { get; set; } = false;
    public DateTime? CreatedDate { get; set; }
}
