using MW.SAXSAY.Core.Application.Contracts.Services;
using MW.SAXSAY.Shared.Helpers;

namespace MW.SAXSAY.Core.Application.Services;

public class TimestampedIdentifierGenerationService : IIdentifierGenerationService
{
    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }

    public string Generate(int numericPortionLength = 15, int stringPortionLength = 6)
    {
        if (numericPortionLength < 15 || stringPortionLength < 6)
            throw new ArgumentException(string.Concat(
                "The length of identifier parts (numeric and string) cannot be less ",
                "than 15 and 6 respectively."));

        string timestampString =
            DateTimeOffset
                .UtcNow
                .ToUnixTimeMilliseconds()
                .ToString(new string('0', numericPortionLength));

        string randomString =
            StringHelpers.RandomString(StringHelpers.PrintableSafe, stringPortionLength);

        return $"{timestampString}{randomString}";
    }
}
