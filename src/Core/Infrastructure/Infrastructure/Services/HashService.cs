using MW.SAXSAY.Core.Application.Contracts;
using System.Security.Cryptography;
using System.Text;

namespace MW.SAXSAY.Core.Infrastructure.Services;

public class HashService : IHashingService
{
    #region Properties & Variables
    private readonly string _hashAlgorithm;
    private readonly int _hashIterations;
    private readonly int _hashKeySize;
    #endregion

    #region Constructor
    public HashService(int? iterations, int? keySize, string? hashAlgorithmName)
    {
        if (iterations == null || iterations < 1)
            throw new ArgumentNullException(nameof(iterations));
        if (keySize == null || keySize < 1)
            throw new ArgumentNullException(nameof(keySize));
        if (string.IsNullOrWhiteSpace(hashAlgorithmName))
            throw new ArgumentNullException(nameof(hashAlgorithmName));

        _hashAlgorithm = hashAlgorithmName.ToString();
        _hashIterations = Convert.ToInt32(iterations);
        _hashKeySize = Convert.ToInt32(keySize);

    }
    #endregion

    #region Methods
    public string HashPassword(string password, byte[] salt)
    {
        var hash = Rfc2898DeriveBytes.Pbkdf2(
            password: Encoding.UTF8.GetBytes(password),
            salt: salt,
            iterations: _hashIterations,
            hashAlgorithm: new HashAlgorithmName(_hashAlgorithm),
            outputLength: _hashKeySize);
        return Convert.ToHexString(hash);
    }

    public bool VerifyPassword(string password, string hash, byte[] salt)
    {
        var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(
            password: password,
            salt: salt,
            iterations: _hashIterations,
            hashAlgorithm: new HashAlgorithmName(_hashAlgorithm),
            outputLength: _hashKeySize);

        return CryptographicOperations.FixedTimeEquals(
            left: hashToCompare,
            right: Convert.FromHexString(hash));
    }
    #endregion
}