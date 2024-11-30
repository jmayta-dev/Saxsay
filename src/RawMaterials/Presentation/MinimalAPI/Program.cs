using MW.SAXSAY.RawMaterials.Application;
using MW.SAXSAY.RawMaterials.Persistence;
using MW.SAXSAY.RawMaterials.Presentation.MinimalApi;

var builder = WebApplication.CreateBuilder(args);
//
// inyección de dependencias
//
builder.Services.AddApplicationLayer();
builder.Services.AddPersistenceLayer();

var app = builder.Build();

app.AddRawMaterialEndpoints();

app.Run();
