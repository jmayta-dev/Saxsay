using MW.SAXSAY.Core.Application.Contracts.Services;
using MW.SAXSAY.Core.Domain.ValueObjects;
using MW.SAXSAY.Shared.Helpers;

namespace MW.SAXSAY.Core.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    #region Properties & Variables
    // dependency
    private IIdentifierGenerationService _identifierGenerationService;
    // private
    private bool _disposed = false;
    #endregion

    #region Disposable Support
    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            if (!_disposed)
            {
                _identifierGenerationService?.Dispose();
            }
            _disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    #endregion

    #region Constructor
    public AuthenticationService(IIdentifierGenerationService identifierGenerationService)
    {
        _identifierGenerationService = identifierGenerationService;
    }
    #endregion

    public Task<AuthenticationResult> LoginAsync(string username, string password, CancellationToken cancellationToken = default)
    {
        return Task.Run(
            () => new AuthenticationResult(
                UserId: new UserId(_identifierGenerationService.Generate()),
                Username: "jdoe",
                FirstName:"John",
                LastName: "Doe",
                Email: "john.doe@fakemail.com",
                IsActive: true,
                DateJoined: DateTime.UtcNow,
                Session: new Session(
                    StringHelpers.RandomString(StringHelpers.PrintableSafe, 32),
                    StringHelpers.RandomString(StringHelpers.PrintableSafe, 128),
                    DateTimeOffset.UtcNow.AddHours(1)))
        );
    }

    public Task<bool> LogoutAsync(string sessionToken, CancellationToken cancellationToken = default)
    {
        return Task.Run(() => true);
    }

    public Task<AuthenticationResult> RegisterAsync(
        string username, string firstName, string lastName, string email, CancellationToken cancellationToken = default)
    {
        return Task.Run(
            () => new AuthenticationResult(
                UserId: new UserId(_identifierGenerationService.Generate()),
                Username: username,
                FirstName: firstName,
                LastName: lastName,
                Email: email,
                IsActive: true,
                DateJoined: DateTime.UtcNow,
                Session: null)
        );
    }
}