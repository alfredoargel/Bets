using Bets.Application.Interfaces;
using Bets.Application.Services;
using Bets.Infrastructure;
using Bets.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bets.WebApi.DependencyInjection
{
    public static class RepositoriesExtension
    {
        public static IServiceCollection AddRepositories(
           this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IRouletteRepository, RouletteRepository>();

            return services;
        }
    }
}
