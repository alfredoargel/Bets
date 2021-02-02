using Bets.Infrastructure.Data.Context;
using Bets.Infrastructure.Data.MongoDB;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bets.WebApi.DependencyInjection
{
    public static class MongoDbInfrastructureExtension
    {
        public static IServiceCollection AddMongoDbPersistence(
          this IServiceCollection services,
          IConfiguration configuration)
        {
            var config = new ServerConfig();
            configuration.Bind(config);
            services.AddScoped<RouletteDBContext>(s => new RouletteDBContext(config.MongoDB));

            return services;
        }
    }
}
