using SistemaIndustrial.Services;
using SistemaIndustrial.Services.Base;

namespace SistemaIndustrial.DependencyInjection
{
    public static class DependencyContext
    {
        public static void ServicesInjection(this IServiceCollection services, bool disableHanFire = false, bool isIntegrationTest = false)
        {
            services.AddScoped<AnimalAppService>();
            services.AddScoped<PecuaristaAppService>();
            services.AddScoped<CompraGadoAppService>();
            services.AddScoped<CompraGadoItemAppService>();
        }
    }
}
