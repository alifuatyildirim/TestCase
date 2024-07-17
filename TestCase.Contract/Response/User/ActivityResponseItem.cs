using TestCase.Common;

namespace TestCase.Contract.Response.User;

public class ActivityResponseItem
{
    public Guid ActivityId { get; set; }
    public ActivityType ActivityType { get; set; }
    public DateTime ActivityTime { get; set; }
    public string Description { get; set; } = string.Empty;
}