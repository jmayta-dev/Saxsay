using AutoMapper;
using MW.SAXSAY.RawMaterials.Application.DTO;

namespace MW.SAXSAY.RawMaterials.Application.Profiles;

public class RawMaterialProfile : Profile
{
    public RawMaterialProfile()
    {
        // from RawMaterialDTO
        CreateMap<RawMaterialDTO, DeleteRawMaterialDTO>();
        CreateMap<RawMaterialDTO, GetRawMaterialDTO>().ReverseMap();

        CreateMap<RawMaterialDTO, RegisterRawMaterialDTO>()
            .ForAllMembers(opts => opts.Condition(
                (src, des, srcMember) => srcMember != null));

        CreateMap<RawMaterialDTO, UpdateRawMaterialDTO>()
            .ForAllMembers(opts => opts.Condition(
                (src, des, srcMember) => srcMember != null));

        // from GetRawMaterialDTO
        CreateMap<GetRawMaterialDTO, RegisterRawMaterialDTO>();
    }
}
