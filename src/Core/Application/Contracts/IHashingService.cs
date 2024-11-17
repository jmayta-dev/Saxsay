namespace MW.SAXSAY.Core.Application.Contracts;

public interface IHashingService
{
    string HashPassword(string password, byte[] salt);
    bool VerifyPassword(string password, string hash, byte[] salt);
}
