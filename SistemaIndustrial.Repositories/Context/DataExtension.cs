using SistemaIndustrial.Repositories.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaIndustrial.Repositories.Context
{
    public static class DataExtension
    {
        public static void UseSisIndDataContext(this IServiceCollection builder, IConfiguration configuration, bool isIntegrationTest = false)
        {
            builder.AddDbContext<SisIndContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                sqlServerOptionsAction: sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 10,
                    maxRetryDelay: TimeSpan.FromSeconds(10),
                    errorNumbersToAdd: null); 
                });
            });
            builder.AddScoped<DbContext, SisIndContext>();

            builder.AddScoped<AnimalRepository>();
            builder.AddScoped<PecuaristaRepository>();
            builder.AddScoped<CompraGadoRepository>();
            builder.AddScoped<CompraGadoItemRepository>();

        }
    }
}
