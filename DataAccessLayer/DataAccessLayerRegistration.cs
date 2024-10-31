using DataAccessLayer.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccessLayer
{
    public static class DataAccessLayerServiceRegistration
    {
        public static IServiceCollection AddDalService(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer("Server=NAFISATAKIYEVA;Database=Test; Trusted_Connection=True;TrustServerCertificate = true"));

            return services;
        }
    }
}