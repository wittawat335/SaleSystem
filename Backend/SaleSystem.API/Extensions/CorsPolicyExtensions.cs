using SaleSystem.Infrastructure.Utility;

namespace SaleSystem.API.Extensions
{
    public static class CorsPolicyExtensions
    {
        public static void ConfigureCorsPolicy(IServiceCollection services, IConfiguration configuration)
        {
            var url = configuration.GetSection(Constants.AppSettings.Client_URL).Value;
            services.AddCors(opt =>
            {
                opt.AddPolicy("newPolicy", builder =>
                {
                    builder.WithOrigins(url).AllowAnyHeader().AllowAnyMethod();
                });
            });
        }
    }
}
