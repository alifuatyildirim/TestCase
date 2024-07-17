using FluentValidation;
using TestCase.Common.Codes;
using TestCase.Common.Extensions;
using TestCase.Contract.Query.User;

namespace TestCase.Application.Handlers.User.Validators;

public class GetUserActivitiesQueryHandlerValidator: AbstractValidator<GetUserActivitiesQuery>
{
    public GetUserActivitiesQueryHandlerValidator()
    {
        this.RuleFor(x => x.Id)
            .NotNull()
            .NotEmpty().WithMessage(ErrorCode.InvalidUserId.GetDescription());
    }
}