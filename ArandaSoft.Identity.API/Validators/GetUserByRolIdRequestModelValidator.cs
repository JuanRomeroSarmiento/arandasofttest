using ArandaSoft.Identity.API.Infrastructure;
using ArandaSoft.Identity.API.Models.Request;
using FluentValidation;

namespace ArandaSoft.Identity.API.Validators
{
    public class GetUserByRolIdRequestModelValidator : AbstractValidator<GetUsersByRolIdRequestModel>
    {
        public GetUserByRolIdRequestModelValidator()
        {
            RuleFor(u => u.RolId)
                .NotNull().WithMessage(Constants.ErrorCurrentRolIdInvalid)
                .NotEmpty().WithMessage(Constants.ErrorCurrentRolIdInvalid)
                .ExclusiveBetween(0, 5).WithMessage(Constants.ErrorCurrentRolIdInvalid);
        }
    }
}
