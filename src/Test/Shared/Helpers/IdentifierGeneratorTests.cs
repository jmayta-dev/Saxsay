
using MW.SAXSAY.Shared.Helpers;

namespace MW.SAXSAY.Test.Shared.Helpers;

public class IdentifierGeneratorTest
{
    [Fact]
    public void Time_and_random_based_can_generate_unique_ids_at_high_load()
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