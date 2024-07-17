using Newtonsoft.Json;
using TestCase.Contract.Abstraction;
using TestCase.Contract.Response.Abstraction;

namespace TestCase.Contract
{
    public class GuidIdResult : IdResult<Guid>
    {
        [JsonConstructor]
        public GuidIdResult(in Guid id)
        {
            this.Id = id;
        }
    }
}
