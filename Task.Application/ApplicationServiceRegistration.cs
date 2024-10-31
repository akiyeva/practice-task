using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Task.Application.Services;

namespace Task.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AppApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<ICategoryService, CategoryManager>();

            return services;
        }
    }
}