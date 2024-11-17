using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW.SAXSAY.RawMaterials.Application.DTO
{
    public record DeleteRawMaterialDTO
    {
        public required string Id { get; init; }
        public string? Name { get; init; }
    }
}
