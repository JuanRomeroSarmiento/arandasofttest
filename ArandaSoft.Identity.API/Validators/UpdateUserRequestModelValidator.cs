using ArandaSoft.Identity.API.Infrastructure;
using ArandaSoft.Identity.API.Models.Request;
using FluentValidation;

namespace ArandaSoft.Identity.API.Validators
{
    public class UpdateUserRequestModelValidator : AbstractValidator<UpdateUserRequestModel>
    {
        public UpdateUserRequestModelValidator()
        {
            RuleFor(u => u.UserId)
                .NotNull().WithMessage(Constants.ErrorCurrentUserIdInvalid)
                .NotEmpty().WithMessage(Constants.ErrorCurrentUserIdInvalid);

            RuleFor(u => u.Email)                
                .EmailAddress().WithMessage(Constants.ErrorCurrentEmailFormatInvalid);

            RuleFor(u => u.RolId)                
                .ExclusiveBetween(0, 5).WithMessage(Constants.ErrorCurrentRolIdInvalid);

            RuleFor(u => u.Age)
                .ExclusiveBetween(0, 150).WithMessage(Constants.ErrorCurrentAgeInvalid);
        }
    }
}
