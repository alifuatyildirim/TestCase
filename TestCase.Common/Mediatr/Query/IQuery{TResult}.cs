using MediatR;

namespace TestCase.Common.Mediatr.Query
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {
    }
}
