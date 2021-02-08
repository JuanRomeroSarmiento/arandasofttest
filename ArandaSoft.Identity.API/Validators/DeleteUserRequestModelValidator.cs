using ArandaSoft.Identity.API.Infrastructure;
using ArandaSoft.Identity.API.Models.Request;
using FluentValidation;
using System;

namespace ArandaSoft.Identity.API.Validators
{
    public class UserIdentifierRequestModelValidator : AbstractValidator<UserIdentifierRequestModel>
    {
        public UserIdentifierRequestModelValidator()
        {
            RuleFor(u => u.UserId)
                .NotNull().WithMessage(Constants.ErrorCurrentUserIdInvalid)
                .NotEmpty().WithMessage(Constants.ErrorCurrentUserIdInvalid)
                .Must(BeAValidGuid).WithMessage(Constants.ErrorCurrentUserIdInvalid);
        }

        private bool BeAValidGuid(Guid guid)
        {
            var tempBool = Guid.TryParse(guid.ToString(), out var result);
            var temp = result;
            return tempBool;
        }

    }
}
