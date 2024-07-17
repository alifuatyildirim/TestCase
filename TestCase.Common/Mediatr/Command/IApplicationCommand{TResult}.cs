using MediatR;

namespace TestCase.Common.Mediatr.Command
{
    public interface IApplicationCommand<out TResult> : IRequest<TResult>
    {
    }
}
