namespace UserCRUDandJWT.Services.Interfaces
{
    public interface IEmailService
    {
        Task SendWelcomeEmailAsync(string toEmail, string username);
        Task SendLoginEmailAsync(string toEmail, string username);
    }

}
