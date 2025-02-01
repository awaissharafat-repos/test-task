using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TestTask.BLL.Interfaces;
using TestTask.BLL.Services;
using TestTask.DAL.Interfaces;
using TestTask.DAL.Services;
using TestTask.Models.EntityModels;
using TestTask.Utilities.AutoMapper;

namespace TestTask.Installers
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MainContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            //services registration
            services.AddScoped<ISessionManager, SessionManager>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IParseCSVService, ParseCSVService>();

            // repo registration
            services.AddScoped<ILoginRepo, LoginRepo>();
            services.AddScoped<IProductRepo, ProductRepo>();

            AutoMapperConfig(services);

            return services;
        }

        private static void AutoMapperConfig(IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(map =>
            {
                map.AddProfile(new AutoMapping());
            });

            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
