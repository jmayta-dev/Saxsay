using MediatR;
using MW.SAXSAY.Domain.Common;
using MW.SAXSAY.RawMaterials.Domain.Entities;
using MW.SAXSAY.RawMaterials.Domain.Interfaces;
using MW.SAXSAY.RawMaterials.Domain.ValueObjects;

namespace MW.SAXSAY.RawMaterials.Application.UseCases.Commands;

public class RegisterRawMaterialCommandHandler
    : IRequestHandler<RegisterRawMaterialCommand, BaseResponse<RawMaterialId>>
{
    #region Properties & Variables
    private readonly IUnitOfWorkRawMaterial _unitOfWorkRawMaterial;
    #endregion

    #region Constructor
    public RegisterRawMaterialCommandHandler(IUnitOfWorkRawMaterial unitOfWorkRawMaterial)
    {
        _unitOfWorkRawMaterial = unitOfWorkRawMaterial;
    }
    #endregion // Constructor

    #region Methods
    public async Task<BaseResponse<RawMaterialId>> Handle(
        RegisterRawMaterialCommand request,
        CancellationToken cancellationToken)
    {
        var response = new BaseResponse<RawMaterialId>();

        // prepare raw material
        RawMaterial.RawMaterialBuilder rawMaterialBuilder = new();
        rawMaterialBuilder.WithDescription(request.Description);
        rawMaterialBuilder.WithStatusActive(true);
        RawMaterial rawMaterial = rawMaterialBuilder.Build();

        try
        {
            RawMaterialId? rawMaterialId =
                await _unitOfWorkRawMaterial
                    .RawMaterialRepository
                    .RegisterAsync(rawMaterial, cancellationToken);

            if (rawMaterialId is not null)
            {
                response.IsSuccess = true;
                response.Data = rawMaterialId;
                response.Message = "Success!";
            }

            await _unitOfWorkRawMaterial.SaveChangesAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
            await _unitOfWorkRawMaterial.RollbackAsync(cancellationToken);
            throw;
        }

        return response;
    }
    #endregion
}