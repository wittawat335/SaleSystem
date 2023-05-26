using SaleSystem.API.Extensions;
using SaleSystem.Core;
using SaleSystem.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

CorsPolicyExtensions.ConfigureCorsPolicy(builder.Services, builder.Configuration);
InfraConfiguration.InjectDependence(builder.Services, builder.Configuration);
CoreConfiguration.RegisterServices(builder.Services);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseCors("newPolicy");
app.MapControllers();
app.Run();
