using Bets.Application.Interfaces;
using Bets.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bets.WebApi.DependencyInjection
{
    public static class ApplicationServicesExtension
    {
        public static IServiceCollection AddApplicationServices(
           this IServiceCollection services)
        {
            services.AddScoped<IRouletteService, RouletteService>();

            return services;
        }
    }
}
