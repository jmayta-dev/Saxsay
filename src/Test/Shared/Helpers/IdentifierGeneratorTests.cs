
using MW.SAXSAY.Shared.Helpers;

namespace MW.SAXSAY.Test.Shared.Helpers;

public class IdentifierGeneratorTest
{
    [Theory]
    [InlineData(0,24)]
    [InlineData(1000,24)]
    [InlineData(6000,24)]
    [InlineData(10000,24)]
    [InlineData(30000,24)]
    public void Time_plus_random_based_ids_same_length_in_any_time(int years, int lengthLimit)
    {
        // Arrange
        string idGenerated = IdentifierGenerators.TimePlusRandomGenerator.Generate(
            yearsInFuture: years);
        int actualLength = idGenerated.Length;
        int expectedLength = lengthLimit;
        // Act
        // Assert
        Assert.Equal(expected:expectedLength, actual:actualLength);
    }

    [Theory]
    [InlineData(0,-1,-1,10000)]
    [InlineData(8,-1,8,10000)]
    [InlineData(13,13,-1,10000)]
    [InlineData(15,15,0,10000)]
    [InlineData(24,15,8,30000)]
    public void Time_plus_random_based_limited_to_number_of_characters(
        int lengthLimit, int timestampedLength, int randomLength, int years)
    {
        // Arrange
        string idGenerated = IdentifierGenerators.TimePlusRandomGenerator.Generate(
            timestampedLength, randomLength, years);
        int actualLength = idGenerated.Length;
        int expectedLength = lengthLimit;
        // Act
        // Assert
        Assert.Equal(expectedLength, actualLength);
    }

    [Fact]
    public void Time_plus_random_based_can_generate_unique_ids_at_high_load()
    {
        // Arrange
        HashSet<string> uniqueIds = new();
        int times = 100000;
        // Act
        for (int i = 0; i < times; i++)
        {
            uniqueIds.Add(IdentifierGenerators.TimePlusRandomGenerator.Generate());
        }
        // Assert
        Assert.Equal(times, uniqueIds.Count);
    }
}