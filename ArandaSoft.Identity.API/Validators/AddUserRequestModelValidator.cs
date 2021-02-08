using ArandaSoft.Identity.API.Infrastructure;
using ArandaSoft.Identity.API.Models.Request;
using FluentValidation;

namespace ArandaSoft.Identity.API.Validators
{
    public class AddUserRequestModelValidator : AbstractValidator<AddUserRequestModel>
    {
        public AddUserRequestModelValidator()
        {
            RuleFor(u => u.UserName)
                .NotNull().WithMessage(Constants.ErrorCurrentUserNameInvalid)
                .NotEmpty().WithMessage(Constants.ErrorCurrentUserNameInvalid);

            RuleFor(u => u.Password)
                .NotNull().WithMessage(Constants.ErrorCurrentPasswordInvalid)
                .NotEmpty().WithMessage(Constants.ErrorCurrentPasswordInvalid);                                

            RuleFor(u => u.FullName)
                .NotNull().WithMessage(Constants.ErrorCurrentFullNameInvalid)
                .NotEmpty().WithMessage(Constants.ErrorCurrentFullNameInvalid);

            RuleFor(u => u.Email)
                .NotNull().WithMessage(Constants.ErrorCurrentEmailInvalid)
                .NotEmpty().WithMessage(Constants.ErrorCurrentEmailInvalid)
                .EmailAddress().WithMessage(Constants.ErrorCurrentEmailFormatInvalid);

            RuleFor(u => u.RolId)
                .NotNull().WithMessage(Constants.ErrorCurrentRolIdEmpty)
                .NotEmpty().WithMessage(Constants.ErrorCurrentRolIdEmpty)
                .ExclusiveBetween(0, 5).WithMessage(Constants.ErrorCurrentRolIdInvalid);
        }
    }
}
