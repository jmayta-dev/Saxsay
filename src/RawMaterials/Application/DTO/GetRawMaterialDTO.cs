namespace MW.SAXSAY.RawMaterials.Application.DTO;

public record GetRawMaterialDTO
{
    public required string Id { get; init; }
    public required string Name { get; init; }
    public string? UNSPSC { get; init; }
    public string? UNSPSCDescription { get; init; }
    public DateTimeOffset? CreatedAt { get; init; }
    public DateTimeOffset? UpdatedAt { get; init; }
    public bool IsEnabled { get; set; }
}
