using System;
namespace notificacions_service.Models.Emails
{
    public static class EmailTemplateMap
    {
        public static readonly IReadOnlyDictionary<EmailTypes, string> Map = new Dictionary<EmailTypes, string>
    {
        { EmailTypes.UserConfirmation, "UserConfirmation.html" },
        { EmailTypes.UserForgotPassword, "UserForgotPassword.html" }
    };
    }

}

