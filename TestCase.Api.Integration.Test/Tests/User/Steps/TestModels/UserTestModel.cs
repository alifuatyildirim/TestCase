using System;

namespace TestCase.Api.Integration.Test.Tests.User.Steps.TestModels;

public class UserTestModel
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime JoinDate { get; set; }
}