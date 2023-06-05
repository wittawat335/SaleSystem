using Microsoft.Extensions.DependencyInjection;
using SaleSystem.Core.AutoMapper;
using SaleSystem.Core.Services;
using SaleSystem.Core.Services.Contract;

namespace SaleSystem.Core
{
    public static class CoreConfiguration
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperProfile));
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ISaleService, SaleService>();
            services.AddScoped<IDashBoardService, DashBoardService>();
            services.AddScoped<IMenuService, MenuService>();
            services.AddScoped<IPasswordHasService, PasswordHashService>();
        }
    }
}
