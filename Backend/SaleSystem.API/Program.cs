using SaleSystem.Core;
using SaleSystem.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

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

app.MapControllers();

app.Run();
