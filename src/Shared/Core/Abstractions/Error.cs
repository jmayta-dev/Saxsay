namespace MW.SAXSAY.Shared.Abstractions;

public sealed class Error(string code, string? description = null)
{
    #region Properties & Variables
    public string Code { get; init; } = code;
    public string? Description { get; init; } = description;

    public static readonly Error None = new(string.Empty);
    #endregion

}
