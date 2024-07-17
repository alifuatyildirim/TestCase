using TestCase.Common;
using TestCase.Domain.Entities.BaseEntity;

namespace TestCase.Domain.Entities;

public class Activity : IEntity<Guid>
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public ActivityType ActivityType { get; set; }
    public DateTime ActivityTime { get; set; } = DateTime.Now;
    public string Description { get; set; } = string.Empty;
}