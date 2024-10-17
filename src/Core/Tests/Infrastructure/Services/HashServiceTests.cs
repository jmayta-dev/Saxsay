using MW.SAXSAY.Core.Infrastructure.Services;
using System.Security.Cryptography;

namespace MW.SAXSAY.Core.Infrastructure.UnitTests.Services;

public class HashServiceTests
{
    [Theory]
    [InlineData(null, null, null)]
    [InlineData(null, null, "SHA512")]
    [InlineData(null, 64, null)]
    [InlineData(null, 64, "SHA512")]
    [InlineData(100000, null, null)]
    [InlineData(100000, null, "SHA512")]
    public void Hashing_instance_fails_without_args(int? iterations, int? keySize, string? hashAlgorithmName)
    {
        // Arrange
        string expectedMessage = "Value cannot be null.";
        void act() => new HashService(iterations, keySize, hashAlgorithmName);

        // Act
        var ex = Record.Exception(act);

        // Assert
        Assert.NotNull(ex);
        Assert.IsType<ArgumentNullException>(ex);
        Assert.Contains(expectedMessage, ex.Message);
    }
    
    [Fact]
    public void Hashing_with_same_args_return_same_result()
    {
        // Arrange
        string password = "a_little_password";
        int keySize = 32;
        int iterations = 100_000;
        string hashAlgorithmName = "SHA256";
        byte[] salt = RandomNumberGenerator.GetBytes(keySize);
        HashService sut = new(iterations, keySize, hashAlgorithmName);

        byte[] expectedHash = Rfc2898DeriveBytes.Pbkdf2(
            password,
            salt,
            iterations,
            new HashAlgorithmName(hashAlgorithmName),
            keySize);

        // Act
        byte[] actualHash = Convert.FromHexString(sut.HashPassword(password, salt));

        // Assert
        Assert.Equal(expectedHash, actualHash);
    }

    [Fact]
    public void Verify_password_with_password_hashed_return_true()
    {
        // Arrange
        string password = "userP4$$w0rd";
        (int keySize, int iterations, string hashAlgorithmName) = (64, 100_000, "SHA512");
        byte[] salt = RandomNumberGenerator.GetBytes(keySize);
        string passwordHashed = Convert.ToHexString(
            Rfc2898DeriveBytes.Pbkdf2(
                password,
                salt,
                iterations,
                new HashAlgorithmName(hashAlgorithmName),
                keySize));

        HashService sut = new(iterations, keySize, hashAlgorithmName);

        // Act
        bool actualResult = sut.VerifyPassword(password, passwordHashed, salt);

        // Assert
        Assert.True(actualResult);
    }
}
