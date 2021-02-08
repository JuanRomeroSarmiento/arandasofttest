using ArandaSoft.Identity.API.Infrastructure;
using ArandaSoft.Identity.API.Models.Request;
using FluentValidation;

namespace ArandaSoft.Identity.API.Validators
{
    public class LoginRequestModelValidator : AbstractValidator<LoginRequestModel>
    {
        public LoginRequestModelValidator()
        {
            RuleFor(u => u.UserName)
                .NotNull().WithMessage(Constants.ErrorCurrentUserNameInvalid)
                .NotEmpty().WithMessage(Constants.ErrorCurrentUserNameInvalid);

            RuleFor(u => u.Password)
                .NotNull().WithMessage(Constants.ErrorCurrentPasswordInvalid)
                .NotEmpty().WithMessage(Constants.ErrorCurrentPasswordInvalid);                
        }
    }
}
