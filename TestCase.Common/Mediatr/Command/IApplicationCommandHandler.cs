using MediatR;

namespace TestCase.Common.Mediatr.Command
{
    public interface IApplicationCommandHandler<in TCommand> : IRequestHandler<TCommand>
        where TCommand : IApplicationCommand
    {
    }
}
