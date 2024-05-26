using Microsoft.Extensions.DependencyInjection;

namespace Vaajak.Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IVocab>
        }
    }
}
