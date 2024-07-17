using TestCase.Common;
using TestCase.Common.Mediatr.Command;

namespace TestCase.Contract.Command.Activity;

public class CreateActivityCommand  : IApplicationCommand<GuidIdResult>
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public Guid? UserId { get; set; }
    public ActivityType ActivityType { get; set; }
    public string Description { get; set; } = string.Empty;
}