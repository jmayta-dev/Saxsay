namespace MW.SAXSAY.RawMaterials.Application.UseCases.Queries.GetAllRawMaterials;

public record GetRawMaterialDTO
{
    public string? Id { get; init; }
    public required string Name { get; set; }
    public string? UNSPSC { get; set; }
    public string? UNSPSCDescription { get; set; }
    public DateTime? CreatedAt { get; init; }
    public bool IsEnabled { get; set; }
}
