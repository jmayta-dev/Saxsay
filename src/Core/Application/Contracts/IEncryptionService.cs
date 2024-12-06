namespace MW.SAXSAY.Core.Application.Contracts;

public interface IEncryptionService
{
    string Encrypt(string value);
    string Decrypt(string value);
    bool Compare(string left, string right);
}
