using MW.SAXSAY.Core.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW.SAXSAY.Core.Infrastructure.UnitTests.Services;

public class TimestampedIdentifierGenerationServiceTests
{
    [Theory]
    [InlineData(15, 6)]
    [InlineData(18, 8)]
    public void Unique_identifier_with_specified_length_returns_correct_length(int numericLength, int stringLength)
    {
        // Arrange
        TimestampedIdentifierGenerationService sut = new();
        int expected = numericLength + stringLength;
        // Act
        var actual = sut.Generate(numericLength, stringLength).Length;
        // Assert
        Assert.Equal(expected, actual);
    }
}
