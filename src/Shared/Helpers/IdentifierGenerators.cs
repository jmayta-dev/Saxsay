namespace MW.SAXSAY.Shared.Helpers;

public static class IdentifierGenerators
{
    public static class TimePlusRandomGenerator
    {
        public static string Generate(
            int timestampedLength = 15, int randomLength = 8, int? yearsInFuture = null)
        {
            string connector = "-";
            string timestampedString = TimestampedString(timestampedLength);
            string randomString = StringHelpers.RandomString(
                StringHelpers.PrintableSafe, randomLength);
            
            if (string.IsNullOrWhiteSpace(timestampedString) ||
                string.IsNullOrWhiteSpace(randomString))
            {
                connector = string.Empty;
            }

            return $"{timestampedString}{connector}{randomString}";
        }

        private static string TimestampedString(int lengthLimit, int? yearsToAdd = null)
        {
            ArgumentNullException.ThrowIfNull(lengthLimit, nameof(lengthLimit));

            if (lengthLimit <= 0)
                return string.Empty;
            string timestampedFormat = new('0', lengthLimit);

            long timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            int minLength = timestamp.ToString().Length;

            if (yearsToAdd != null && yearsToAdd > 0)
                timestamp += (long)(yearsToAdd * 365.25 * 24 * 60 * 60 * 1000);

            string timestampString = timestamp.ToString();

            // timestamp length checking
            int timestampLength = timestampString.Length;
            if (timestampLength > lengthLimit)
                throw new Exception($"Length limit excedeed. Minimal length must be {minLength}");

            return timestamp.ToString(timestampedFormat);
        }
    }
}
