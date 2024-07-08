namespace MW.SAXSAY.Shared.Helpers;

public static class IdentifierGenerators
{
    public static class TimePlusRandomGenerator
    {
        public static string Generate()
        {
            var timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            var randomString = StringHelpers.RandomString(StringHelpers.PrintableSafe, 8);
            return $"{timestamp}-{randomString}";
        }
    }
}