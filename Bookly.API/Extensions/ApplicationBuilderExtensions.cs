using Bookly.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Writers;
using static System.Formats.Asn1.AsnWriter;

namespace Bookly.API.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            using var dbContext= scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            dbContext.Database.Migrate();
        }
    }
}
