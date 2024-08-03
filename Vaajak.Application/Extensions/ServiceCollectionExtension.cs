using Microsoft.Extensions.DependencyInjection;
using Vaajak.Application.Services.Packages;
using Vaajak.Application.Services.Vocabs;

namespace Vaajak.Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IVocabService, VocabService>();
            services.AddScoped<IPackageService, PackageService>();
        }
    }
}
