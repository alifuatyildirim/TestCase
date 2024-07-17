using TestCase.Common;
using TestCase.Common.Mediatr.Query;
using TestCase.Contract.Response.User;

namespace TestCase.Contract.Query.Activities;

public class GetAllActivitiesQuery: IQuery<AllActivityResponse>
{
    public Guid? UserId { get; set; }
    public ActivityType? ActivityType { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}