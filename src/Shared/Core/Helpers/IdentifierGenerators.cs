using MW.SAXSAY.Shared.Contracts;

namespace MW.SAXSAY.Shared.Helpers;

public static class IdentifierGenerators
{
    public static class TimePlusRandomGenerator
    {
        public static string Generate(
            int timestampedLength = 15, int randomLength = 8)
        {
            string connector = "-";
            string timestampedString = TimestampedString(timestampedLength);
            string randomString = StringHelpers.RandomString(
                StringHelpers.PrintableSafe, randomLength);
            
            if (string.IsNullOrWhiteSpace(timestampedString)
                || string.IsNullOrWhiteSpace(randomString))
                connector = string.Empty;

            return $"{timestampedString}{connector}{randomString}";
        }

        public static string Generate()
        {
            return Generate(15,8);
        }

        private static string TimestampedString(int lengthLimit)
        {
            ArgumentNullException.ThrowIfNull(lengthLimit);

            if (lengthLimit <= 0) return string.Empty;

            string timestampedFormat = new('0', lengthLimit);

            long timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            short minLength = Convert.ToInt16(timestamp.ToString().Length);

            string timestampString = timestamp.ToString();

            // timestamp length checking
            int timestampLength = timestampString.Length;
            if (timestampLength > lengthLimit)
                throw new Exception($"Length limit excedeed. Minimal length must be {minLength}");

            return timestamp.ToString(timestampedFormat);
        }
    }
}
