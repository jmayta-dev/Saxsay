using MW.SAXSAY.Shared.Helpers;

namespace MW.SAXSAY.Test.Shared.Helpers;

public class StringHelpersTests
{
    [Theory]
    [InlineData(1)]
    [InlineData(20)]
    [InlineData(0)]
    public void Can_generate_random_string_with_length(int length)
    {
        // Arrange
        // Act
        var randomString = StringHelpers.RandomString(
            StringHelpers.PrintableSafe, length);
        // Assert
        Assert.Equal(randomString.Length, length);
    }
}