﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EF.WOrkshop.Persistence
{
    public static class PersistenceDiConfiguration
    {
        public static void AddPersistence(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("PostgresCS");

            services.AddDbContext<AppDbContext>(
                options =>
                options.UseNpgsql(
                        connectionString,
                        sqlOptions =>
                        {
                            sqlOptions.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName);
                            sqlOptions.EnableRetryOnFailure(
                                maxRetryCount: 15,
                                maxRetryDelay: TimeSpan.FromSeconds(30),
                                errorCodesToAdd: null);
                        }),
                ServiceLifetime.Transient);

        }
    }
}
