using MediatR;

namespace TestCase.Common.Mediatr.Command
{
    public interface IDomainCommandHandler<in TCommand> : IRequestHandler<TCommand>
        where TCommand : IDomainCommand
    {
    }
}
