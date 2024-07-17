using FluentValidation;
using TestCase.Common;
using TestCase.Common.Codes;
using TestCase.Common.Extensions;
using TestCase.Contract.Command.Activity;

namespace TestCase.Application.Handlers.Activity.Validators;


public class CreateActivityCommandValidator :AbstractValidator<CreateActivityCommand>
{
    public CreateActivityCommandValidator()
    {
        this.RuleFor(x => x.Name).NotEmpty().NotNull().When(x => x.ActivityType == ActivityType.Signup)
            .WithMessage(x => ErrorCode.EmptyName.GetDescription());
        
        this.RuleFor(x => x.Email).NotEmpty().NotNull().When(x => x.ActivityType == ActivityType.Signup)
            .WithMessage(ErrorCode.EmptyEmail.GetDescription()).EmailAddress().WithMessage(ErrorCode.InvalidEmail.GetDescription());
        
        this.RuleFor(x => x.UserId).NotEmpty().When(x=>x.ActivityType!=ActivityType.Signup).WithMessage(ErrorCode.EmptyUserId.GetDescription());
        this.RuleFor(x => x.ActivityType).IsInEnum().NotNull();
    }
}