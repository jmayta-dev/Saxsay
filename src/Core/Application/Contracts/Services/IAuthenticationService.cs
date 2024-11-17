using MW.SAXSAY.Core.Application.Services.Authentication;

namespace MW.SAXSAY.Core.Application.Contracts.Services;

public interface IAuthenticationService : IDisposable
{
    Task<AuthenticationResult> LoginAsync(string username, string password, CancellationToken cancellationToken = default);
    Task<bool> LogoutAsync(string sessionToken, CancellationToken cancellationToken = default);
    Task<AuthenticationResult> RegisterAsync(string username, string firstName, string lastName, string email, CancellationToken cancellationToken = default);
}