using Newtonsoft.Json;
using TestCase.Common.Mediatr.Query;
using TestCase.Contract.Response.User;

namespace TestCase.Contract.Query.User;

public class GetUserActivitiesQuery: IQuery<ActivityResponse>
{
    [JsonIgnore]
    public Guid Id { get; set; }
}