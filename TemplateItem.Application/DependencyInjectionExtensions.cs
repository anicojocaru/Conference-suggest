using Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RatingSystem.Application;



namespace RatingSystem.Application
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection RegisterBusinessServices(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddSingleton<Data.RatingDbContext>();

            //services.AddSingleton(sp =>
            //{
            //    var config = sp.GetRequiredService<IConfiguration>();
            //    return config;
            //});
            return services;
        }
    }
}
