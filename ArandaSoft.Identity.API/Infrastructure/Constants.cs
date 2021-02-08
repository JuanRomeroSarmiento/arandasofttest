namespace ArandaSoft.Identity.API.Infrastructure
{
    public static class Constants
    {

        #region Error Constants

        public const string ErrorUserNamePasswordIncorrect = "The username or password you entered is incorrect, please try again.";
        public const string ErrorForbiddenAction = "Not action allowed.";
        public const string ErrorCurrentUserIdInvalid = "User Id is not valid, please try again.";
        public const string ErrorCurrentUserNameInvalid = "UserName is not valid, please try again.";
        public const string ErrorCurrentPasswordInvalid = "Password is not valid, please try again.";
        public const string ErrorCurrentFullNameInvalid = "Fullname is not valid, please try again.";
        public const string ErrorCurrentAgeInvalid = "Age is not valid, please try again.";
        public const string ErrorCurrentEmailInvalid = "Email is not valid, please try again.";
        public const string ErrorCurrentEmailFormatInvalid = "Email is not valid. A valid format is required, please try again.";
        public const string ErrorCurrentRolIdInvalid = "RolId is not valid, please try again.";
        public const string ErrorCurrentRolIdEmpty = "User must be assigned a role, please try again.";
        public const string ErrorCurrentPasswordInvalidLength = "Password must be at least 8 characters, please try again.";

        #endregion

        #region Policy Claims Configuration

        public const string SelectPolicy = "SelectPolicy";
        public const string CreatePolicy = "CreatePolicy";
        public const string UpdatePolicy = "EditPolicy";
        public const string DeletePolicy = "DeletePolicy";

        public const string SelectPolicyName = "Select";
        public const string CreatePolicyName = "Create";
        public const string UpdatePolicyName = "Edit";
        public const string DeletePolicyName = "Delete";

        public const string SelectPolicyKey = "SelectPermission";
        public const string CreatePolicyKey = "CreatePermission";
        public const string UpdatePolicyKey = "EditPermission";
        public const string DeletePolicyKey = "DeletePermission";

        #endregion

    }
}
