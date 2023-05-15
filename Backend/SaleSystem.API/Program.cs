using SaleSystem.Core;
using SaleSystem.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

CoreConfiguration.RegisterServices(builder.Services);
InfraConfiguration.InjectDependence(builder.Services, builder.Configuration);

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
