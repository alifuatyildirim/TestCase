using TestCase.Contract.Response.Abstraction;

namespace TestCase.Contract.Response.User;

public class ActivityResponse : PagedItems<ActivityResponseItem>
{
    public Guid UserId { get; set; }
}