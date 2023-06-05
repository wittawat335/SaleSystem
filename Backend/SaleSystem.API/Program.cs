using SaleSystem.API.Extensions;
using SaleSystem.Core;
using SaleSystem.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureCorsPolicy(builder.Configuration); // from SaleSystem.API/Extensions
builder.Services.ConfigureJwtPolicy(builder.Configuration); // from SaleSystem.API/Extensions
builder.Services.InjectDependence(builder.Configuration); // from SaleSystem.Infrastructure
builder.Services.RegisterServices(); //from SaleSystem.Core

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("newPolicy");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
