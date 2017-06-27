namespace DPEP.Common.BLL.Helpers
{
    public class ResponseBadRequest
    {
        public const int cImageFormat = 1;
        public const int cFileEmpty = 2;
        public const int cTokenMissing = 3;
        public const int cAntiForgeryTokenExpiry = 4;
        public const int cAntiForgeryRelated = 5;
        public const int cProjectCreationFailed = 6;
        public const int cAuthenticationFailed = 7;
        public const int cActionNotAllowed = 8;
        public const int cTeamCreationFailed = 9;
        public const int cRoleCreationFailedByUser = 10;

        public const int cInvalidCaptcha = 11;
        public const int cRoleCreationFailedByTeam = 12;
        public const int cRoleCreationFailedNameEmpty = 13;
        public const int cUserCreationFailedInvalidEmail = 14;
        public const int cAccountDuplication = 15;
        public const int cGetEmailTokenFailed = 16;
        public const int cResetPasswordFailed = 17;
        public const int cValidateEmailTokenFailed = 18;
        public const int cUserCreationFailedNameEmpty = 19;
        public const int cUserCreationFailedIncorrectPasswordFormat = 20;
        public const int cContactUsCreationFailedRequiredFieldsEmpty = 21;
        public const int cContactUsCreationFailedEmailFormatEmpty = 22;
        public const int cUploadingDocumentFailed = 23;
        public const int cFileTooLarge = 24;
        public const int cEmailNotFound = 25;

        public const int cProjectUserNotFound = 26;
        public const int cProjectNameEmpty = 27;
        public const int cProjectStartdateInvalid = 28;
        public const int cProjectTimeFrameNotFound = 29;
        public const int cProjectDescriptionEmpty = 30;
        public const int cProjectBudgetInvalid = 31;
        public const int cProjectCurrencyInvalid = 32;

        public const int cUserUnverified = 33;

        public const int cNewLeadContacts = 34;
        public const int cLeadContactCreationFailed = 35;
        public const int cUpdateLeadContacts = 35;
        public const int cUpdateProject = 36;

        public int ErrImageFormat { get { return cImageFormat; } }
        public int ErrFileEmpty { get { return cFileEmpty; } }
        public int ErrTokenMissing { get { return cTokenMissing; } }
        public int ErrAntiForgeryTokenExpiry { get { return cAntiForgeryTokenExpiry; } }
        public int ErrAntiForgeryRelated { get { return cAntiForgeryRelated; } }
        public int ErrProjectCreationFailed { get { return cProjectCreationFailed; } }
        public int ErrAuthenticationFailed { get { return cAuthenticationFailed; } }
        public int ErrActionNotAllowed { get { return cActionNotAllowed; } }
        public int ErrTeamCreationFailed { get { return cTeamCreationFailed; } }
        public int ErrRoleCreationFailedByUser { get { return cRoleCreationFailedByUser; } }
        public int ErrInvalidCaptcha { get { return cInvalidCaptcha; } }
        public int ErrRoleCreationFailedByTeam { get { return cRoleCreationFailedByTeam; } }
        public int ErrRoleCreationFailedNameEmpty { get { return cRoleCreationFailedNameEmpty; } }
        public int ErrUserCreationFailedInvalidEmail { get { return cUserCreationFailedInvalidEmail; } }
        public int ErrAccountDuplication { get { return cAccountDuplication; } }
        public int ErrGetEmailTokenFailed { get { return cGetEmailTokenFailed; } }
        public int ErrResetPasswordFailed { get { return cResetPasswordFailed; } }
        public int ErrValidateEmailTokenFailed { get { return cValidateEmailTokenFailed; } }
        public int ErrUserCreationFailedNameEmpty { get { return cUserCreationFailedNameEmpty; } }
        public int ErrUserCreationFailedIncorrectPasswordFormat { get { return cUserCreationFailedIncorrectPasswordFormat; } }
        public int ErrContactUsCreationFailedRequiredFieldsEmpty { get { return cContactUsCreationFailedRequiredFieldsEmpty; } }
        public int ErrContactUsCreationFailedEmailFormatEmpty { get { return cContactUsCreationFailedEmailFormatEmpty; } }
        public int ErrUploadingDocumentFailed { get { return cUploadingDocumentFailed; } }
        public int ErrFileTooLarge { get { return cFileTooLarge; } }
        public int ErrEmailNotFound { get { return cEmailNotFound; } }

        public int ErrProjectUserNotFound { get { return cProjectUserNotFound; } }
        public int ErrProjectNameEmpty { get { return cProjectNameEmpty; } }
        public int ErrProjectStartdateInvalid { get { return cProjectStartdateInvalid; } }
        public int ErrProjectTimeFrameNotFound { get { return cProjectTimeFrameNotFound; } }
        public int ErrProjectDescriptionEmpty { get { return cProjectDescriptionEmpty; } }
        public int ErrProjectBudgetInvalid { get { return cProjectBudgetInvalid; } }
        public int ErrProjectCurrencyInvalid { get { return cProjectCurrencyInvalid; } }

        public int ErrUserUnverified { get { return cUserUnverified; } }

        public int ErrNewLeadContact { get { return cNewLeadContacts; } }
        public int ErrLeadContactCreationFailed { get { return cLeadContactCreationFailed; } }
        public int ErrUpdateLeadContact { get { return cUpdateLeadContacts; } }
        public int ErrUpdateProject { get { return cUpdateProject; } }

        public Error ShowError(int errorCode)
        {

            return GetCorrespondingError(errorCode);
        }

        private Error GetCorrespondingError(int errorCode)
        {

            if (errorCode == ErrImageFormat)
            {
                return new Error
                {
                    Status = 500,
                    Title = "Sketch, Psd, Pdf, Png, Jpeg and Gif only",
                    Details = "File format not supported."
                };
            }
            if (errorCode == ErrFileEmpty)
            {
                return new Error
                {
                    Status = 500,
                    Title = "File is empty",
                    Details = "Kindly upload atleast one(1) document file."
                };
            }
            if (errorCode == ErrTokenMissing)
            {
                return new Error
                {
                    Status = 500,
                    Title = "X-XSRF-TOKEN is missing",
                    Details = "Request headers must contain the Antiforgery token."
                };
            }
            if (errorCode == ErrAntiForgeryTokenExpiry)
            {
                return new Error
                {
                    Status = 500,
                    Title = "Antiforgery Token Expired",
                    Details = "The token is no longer valid since it had expired."
                };
            }
            if (errorCode == ErrAntiForgeryRelated)
            {
                return new Error
                {
                    Status = 500,
                    Title = "Antiforgery Related Error",
                    Details = "Antiforgery Related Error"
                };
            }
            if (errorCode == ErrProjectCreationFailed)
            {
                return new Error
                {
                    Status = 500,
                    Title = "Failed! New Project",
                    Details = "Error creating new project"
                };
            }
            if (errorCode == ErrAuthenticationFailed)
            {
                return new Error
                {
                    Status = 500,
                    Title = "Authentication Failed",
                    Details = "Invalid username or password."
                };
            }
            if (errorCode == ErrActionNotAllowed)
            {
                return new Error
                {
                    Status = 500,
                    Title = "Action Not Allowed",
                    Details = "You are only limited to viewing your own account."
                };
            }
            if (errorCode == ErrTeamCreationFailed)
            {
                return new Error
                {
                    Status = 500,
                    Title = "Failed Creating New Team.",
                    Details = "Unable to successfully create a new team for selected project"
                };
            }
            if (errorCode == ErrRoleCreationFailedByUser)
            {
                return new Error
                {
                    Status = 500,
                    Title = "Failed Creating New Role.",
                    Details = "User Id or Project Id is invalid for it is not found in the server."
                };
            }
            if (errorCode == ErrInvalidCaptcha)
            {
                return new Error
                {
                    Status = 500,
                    Title = "Invalid Captcha",
                    Details = "The captcha has failed the validation."
                };
            }
            if (errorCode == ErrRoleCreationFailedByTeam)
            {
                return new Error
                {
                    Status = 500,
                    Title = "Failed Creating New Role.",
                    Details = "Team Number is invalid for it is not found in the server."
                };
            }
            if (errorCode == ErrRoleCreationFailedNameEmpty)
            {
                return new Error
                {
                    Status = 500,
                    Title = "Failed Creating New Role.",
                    Details = "Role name cannot be empty."
                };
            }
            if (errorCode == ErrUserCreationFailedInvalidEmail)
            {
                return new Error
                {
                    Status = 500,
                    Title = "Failed Creating New User.",
                    Details = "Invalid email format."
                };
            }
            if (errorCode == ErrAccountDuplication)
            {
                return new Error
                {
                    Status = 500,
                    Title = "Account Duplication Detected.",
                    Details = "The email already exist."
                };
            }
            if (errorCode == ErrGetEmailTokenFailed)
            {
                return new Error
                {
                    Status = 500,
                    Title = "Failed To Get Email Token",
                    Details = "Email does not seem to exist."
                };
            }
            if (errorCode == ErrResetPasswordFailed)
            {
                return new Error
                {
                    Status = 500,
                    Title = "Failed To Reset Password",
                    Details = "User not found or invalid password."
                };
            }
            if (errorCode == ErrValidateEmailTokenFailed)
            {
                return new Error
                {
                    Status = 500,
                    Title = "Failed to Validate Email Token",
                    Details = "Invalid Token"
                };
            }
            if (errorCode == ErrUserCreationFailedNameEmpty)
            {
                return new Error
                {
                    Status = 500,
                    Title = "Failed Creating New User.",
                    Details = "First name and last name cannot be empty."
                };
            }
            if (errorCode == ErrUserCreationFailedIncorrectPasswordFormat)
            {
                return new Error
                {
                    Status = 500,
                    Title = "Failed Creating New User.",
                    Details = "Password must contain at least 8 characters, including uppercase, " +
                        "lowercase letters and numbers."
                };
            }
            if (errorCode == ErrContactUsCreationFailedRequiredFieldsEmpty)
            {
                return new Error
                {
                    Status = 500,
                    Title = "Failed! Contact Us.",
                    Details = "Fill in all fields."
                };
            }
            if (errorCode == ErrContactUsCreationFailedEmailFormatEmpty)
            {
                return new Error
                {
                    Status = 500,
                    Title = "Failed! Contact Us.",
                    Details = "Invalid email format."
                };
            }
            if (errorCode == ErrUploadingDocumentFailed)
            {
                return new Error
                {
                    Status = 500,
                    Title = "Failed uploading document.",
                    Details = "Project Id is invalid for it is not found in the server."
                };
            }
            if (errorCode == ErrFileTooLarge)
            {
                return new Error
                {
                    Status = 500,
                    Title = "File is too large.",
                    Details = "Limit of 20Mb only."
                };
            }
            if (errorCode == ErrEmailNotFound)
            {
                return new Error
                {
                    Status = 500,
                    Title = "Failed! Email not found.",
                    Details = "Email not found"
                };
            }
            if (errorCode == ErrProjectUserNotFound)
            {
                return new Error
                {
                    Status = 500,
                    Title = "Failed!New Project.",
                    Details = "User Id is invalid for it is not found in the server."
                };
            }
            if (errorCode == ErrProjectNameEmpty)
            {
                return new Error
                {
                    Status = 500,
                    Title = "Failed!New Project.",
                    Details = "Project Name cannot be empty."
                };
            }
            if (errorCode == ErrProjectStartdateInvalid)
            {
                return new Error
                {
                    Status = 500,
                    Title = "Failed!New Project.",
                    Details = "Invalid Start Date."
                };
            }
            if (errorCode == ErrProjectTimeFrameNotFound)
            {
                return new Error
                {
                    Status = 500,
                    Title = "Failed!New Project.",
                    Details = "TimeFrame Id is invalid for it is not found in the server."
                };
            }
            if (errorCode == ErrProjectDescriptionEmpty)
            {
                return new Error
                {
                    Status = 500,
                    Title = "Failed!New Project.",
                    Details = "Project Description cannot be empty."
                };
            }
            if (errorCode == ErrProjectBudgetInvalid)
            {
                return new Error
                {
                    Status = 500,
                    Title = "Failed!New Project.",
                    Details = "Budget must be greater than 0."
                };
            }
            if (errorCode == ErrProjectCurrencyInvalid)
            {
                return new Error
                {
                    Status = 500,
                    Title = "Failed!New Project.",
                    Details = "Currency Id is invalid for it is not found in the server."
                };
            }
            if (errorCode == ErrUserUnverified)
            {
                return new Error
                {
                    Status = 403,
                    Title = "Email Unverified",
                    Details = "Please verify your email and get started using your DevPartners account."
                };
            }
            if (errorCode == ErrNewLeadContact)
            {
                return new Error
                {
                    Status = 500,
                    Title = "Failed! New Lead Contact",
                    Details = "Failed to create New Lead due to empty fields."
                };
            }
            if (errorCode == ErrLeadContactCreationFailed)
            {
                return new Error
                {
                    Status = 500,
                    Title = "Failed! New Lead Contact",
                    Details = "Error creating new lead contact."
                };
            }
            if (errorCode == ErrUpdateLeadContact)
            {
                return new Error
                {
                    Status = 500,
                    Title = "Failed! Update Contact",
                    Details = "Failed to update Lead."
                };
            }
            if (errorCode == ErrUpdateProject)
            {
                return new Error
                {
                    Status = 500,
                    Title = "Failed! Update Project",
                    Details = "Failed to update Project."
                };
            }
            return null;
        }
        public class Error
        {
            public int Status { get; set; }
            public string Title { get; set; }
            public string Details { get; set; }
        }
    }
}