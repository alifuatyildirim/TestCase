using TestCase.Domain.Entities.BaseEntity;

namespace TestCase.Domain.Entities;

public class User : IEntity<Guid>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime JoinDate { get; set; } = DateTime.Now;
}