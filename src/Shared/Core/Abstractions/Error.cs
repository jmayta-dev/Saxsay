namespace MW.SAXSAY.Shared.Abstractions;

public sealed class Error(string Code, string? Description = null)
{
    public static readonly Error None = new(string.Empty);
}
