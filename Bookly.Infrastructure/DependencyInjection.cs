using Bookify.Infrastructure.Authentication;
using Bookly.Application.Abstractions.Authentication;
using Bookly.Application.Abstractions.Clock;
using Bookly.Application.Abstractions.Data;
using Bookly.Application.Abstractions.Email;
using Bookly.Domain.Abstractions;
using Bookly.Domain.Apartments;
using Bookly.Domain.Bookings;
using Bookly.Domain.Users;
using Bookly.Infrastructure.Authentication;
using Bookly.Infrastructure.Clock;
using Bookly.Infrastructure.Data;
using Bookly.Infrastructure.Email;
using Bookly.Infrastructure.Repositories;
using Dapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Bookly.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IDateTimeProvider, DateTimeProvider>();
            services.AddTransient<IEmailService, EmailService>();
            AddPersistence(services, configuration);
            services
                .AddAuthentication(Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer();

            services.Configure<AuthenticationOptions>(configuration.GetSection("Authentication"));

            services.ConfigureOptions<JwtBearerOptionsSetup>();
            services.Configure<KeycloakOptions>(configuration.GetSection("Keycloak"));
            services.AddHttpClient<IAuthenticationService, AuthenticationService>((serviceProvider, httpClient) =>
            {
                var keycloakOptions = serviceProvider.GetRequiredService<IOptions<KeycloakOptions>>().Value;

                httpClient.BaseAddress = new Uri(keycloakOptions.AdminUrl);
            })
    .AddHttpMessageHandler<AdminAuthorizationDelegatingHandler>();

            return services;
        }

        private static void AddPersistence(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Database") ??
                            throw new ArgumentNullException(nameof(configuration));
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(connectionString).UseSnakeCaseNamingConvention();
            });
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IApartmentRepository, ApartmentRepository>();
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());

            services.AddSingleton<ISqlConnectionFactory>(_ =>
    new SqlConnectionFactory(connectionString));

            SqlMapper.AddTypeHandler(new DateOnlyTypeHandler());
        }
    }
}
