using TestCase.Domain.Repositories;

namespace TestCase.Api.Integration.Test.Tests.User
{
    public class UserFixture
    {
        public UserFixture(IUserRepository userRepository, IUserRepositoryForTest userRepositoryForTest)
        {
            this.UserRepository = userRepository;
            this.UserRepositoryForTest = userRepositoryForTest;
        }

        public IUserRepository UserRepository { get; }
        public IUserRepositoryForTest UserRepositoryForTest { get; } 
    }
}
