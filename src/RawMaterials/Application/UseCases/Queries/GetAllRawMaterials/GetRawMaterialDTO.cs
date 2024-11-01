namespace MW.SAXSAY.RawMaterials.Application.UseCases.Queries.GetAllRawMaterials
{
    public record GetRawMaterialDTO
    {
        public string? Id { get; init;  }
        public required string Name { get; init; }
        public string? UNSPSC { get; init; }
        public string? UNSPSCDescription { get; init; }
        public DateTime? CreatedAt { get; init; }
        public bool IsEnabled { get; init; }
    }
}
