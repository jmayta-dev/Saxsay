namespace MW.SAXSAY.RawMaterials.Application.DTO;

public record RegisterRawMaterialDTO
{
    public required string Id { get; init; }
    public required string Name { get; set; }
    public string UNSPSC { get; init; } = string.Empty;
    public string UNSPSCDescription { get; init; } = string.Empty;
    public DateTimeOffset? CreatedAt { get; init; } = DateTimeOffset.UtcNow;
    public DateTimeOffset? UpdatedAt { get; init; } = DateTimeOffset.UtcNow;
    public bool IsEnabled { get; init; } = true;
}