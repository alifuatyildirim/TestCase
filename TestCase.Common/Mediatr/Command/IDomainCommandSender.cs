namespace TestCase.Common.Mediatr.Command
{
    public interface IDomainCommandSender
    {
        Task SendAsync(IDomainCommand command);
    }
}
