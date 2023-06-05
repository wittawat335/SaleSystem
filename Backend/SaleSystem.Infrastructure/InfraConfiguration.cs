using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SaleSystem.Core.Domain.RepositoryContracts;
using SaleSystem.Infrastructure.DBContext;
using SaleSystem.Infrastructure.Repositories;
using SaleSystem.Infrastructure.Utility;

namespace SaleSystem.Infrastructure
{
    public static class InfraConfiguration
    {
        public static void InjectDependence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SaleSystemDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString(Constants.ConnnectionString.SqlServer));
            });

            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>)); 
            services.AddScoped<ISaleRepository, SaleRepository>();
        }
    }
}
