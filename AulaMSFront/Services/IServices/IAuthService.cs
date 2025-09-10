using AulaMSFront.Models;

namespace AulaMSFront.Services.IServices
{
    public interface IAuthService
    {
        Task<string> LoginAsync(LoginModel login);
    }
}
