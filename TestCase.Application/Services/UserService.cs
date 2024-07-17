using System.Net;
using MapsterMapper;
using TestCase.Common.Codes;
using TestCase.Common.ExceptionHandling;
using TestCase.Common.Extensions;
using TestCase.Domain.Entities;
using TestCase.Application.Services.Abstraction;
using TestCase.Contract.Response.User;
using TestCase.Domain.Repositories;

namespace TestCase.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository userRepository;
    private readonly IMapper mapper;

    public UserService(IMapper mapper, IUserRepository userRepository)
    {
        this.mapper = mapper;
        this.userRepository = userRepository;
    }

    public async Task<ActivityResponse> GetUserActivitiesAsync(Guid id, CancellationToken cancellationToken)
    {
        User? user = await this.userRepository.GetAsync(id);
        
        if (user is null)
        {
            throw new TestCaseException(ErrorCode.InvalidUserId,
                ErrorCode.InvalidUserId.GetDescription(), HttpStatusCode.NotFound);
        }

        return this.mapper.Map<ActivityResponse>(user);
    }

    
}