using AutoMapper;
using MW.SAXSAY.RawMaterials.Application.DTO;

namespace MW.SAXSAY.RawMaterials.Application.Profiles;

public class RawMaterialProfile : Profile
{
    public RawMaterialProfile()
    {
        // from RawMaterialDTO
        CreateMap<RawMaterialDTO, GetRawMaterialDTO>().ReverseMap();
    }
}
