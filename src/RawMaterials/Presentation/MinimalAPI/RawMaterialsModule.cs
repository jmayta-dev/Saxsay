using MediatR;
using MW.SAXSAY.RawMaterials.Application.DTO;
using MW.SAXSAY.RawMaterials.Application.UseCases.Commands.RegisterRawMaterials;
using MW.SAXSAY.RawMaterials.Application.UseCases.Queries.GetAllRawMaterials;

namespace MW.SAXSAY.RawMaterials.Presentation.MinimalApi;

public static class RawMaterialsModule
{
    public static void AddRawMaterialEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/", () => "Hello MistiHack!");

        app.MapGet("/rawMaterials/list", async (ISender sender) =>
        {
            var lista = await sender.Send(new GetAllRawMaterialsQuery());

            return Results.Ok(lista);
        });

        app.MapPost(
            "/rawMaterials/register/",
            async (RegisterRawMaterialDTO rawMaterial, ISender sender) =>
            {
                var listRawMaterial = new List<RegisterRawMaterialDTO>
                {
                    rawMaterial
                };
                var response = await sender.Send(new RegisterRawMaterialCommand(listRawMaterial));
                Results.Created();
            });
    }
}