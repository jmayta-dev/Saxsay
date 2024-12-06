namespace MW.SAXSAY.RawMaterials.Application.DTO;

public record RawMaterialDTO
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? UNSPSC { get; set; }
    public string? UNSPSCDescription { get; set; }
    public DateTimeOffset? CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    public bool? IsEnabled { get; set; }
}
