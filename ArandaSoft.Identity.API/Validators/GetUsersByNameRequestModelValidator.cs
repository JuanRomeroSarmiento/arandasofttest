using ArandaSoft.Identity.API.Infrastructure;
using ArandaSoft.Identity.API.Models.Request;
using FluentValidation;

namespace ArandaSoft.Identity.API.Validators
{
    public class GetUsersByNameRequestModelValidator : AbstractValidator<GetUsersByNameRequestModel>
    {
        public GetUsersByNameRequestModelValidator()
        {
            RuleFor(u => u.UserName)
               .NotNull().WithMessage(Constants.ErrorCurrentUserNameInvalid)
               .NotEmpty().WithMessage(Constants.ErrorCurrentUserNameInvalid);
        }
    }
}
