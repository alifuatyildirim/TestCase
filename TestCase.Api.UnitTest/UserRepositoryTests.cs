using TestCase.Data.Repositories;
using TestCase.Domain.Entities;
using TestCase.Domain.Repositories.Base;
using Moq;

namespace TestCase.Api.UnitTest;

[TestFixture]
public class UserRepositoryTests
{
    private readonly Mock<IGenericRepository<User, Guid>> genericRepositoryMock;
    private readonly UserRepository userRepository;
    public UserRepositoryTests()
    {
        this.genericRepositoryMock = new Mock<IGenericRepository<User, Guid>>();
        this.userRepository = new UserRepository(genericRepositoryMock.Object);
    }
    [Test]
    public async Task CreateAsync_Should_Return_New_User_Id()
    {
        // Arrange
        var user = new User
        {
            Id = Guid.NewGuid(),
            Email = "ali@ali.com",
        };

        genericRepositoryMock.Setup(repo => repo.AddOneAsync(user, It.IsAny<ITransactionScope>()))
            .Returns(Task.CompletedTask);

        // Act
        var result = await userRepository.CreateAsync(user, null);

        // Assert
        Assert.That(result, Is.Not.EqualTo(Guid.Empty));
    }
    
    [Test]
    public async Task GetAsync_Should_Return_User()
    {
        // Arrange

        var userId = Guid.NewGuid(); 
        var user = new User
        {
            Id = userId,
            Email = "ali@ali.com",
        };


        genericRepositoryMock.Setup(repo => repo.GetByIdAsync(userId))
            .ReturnsAsync(user);

        // Act
        var result = await userRepository.GetAsync(userId);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result!.Id, Is.EqualTo(userId));
    }
}