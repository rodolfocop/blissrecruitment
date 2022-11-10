using DotNetCore.EntityFrameworkCore;
using DotNetCore.IoC;
using Bliss.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace Bliss.API.Configurations
{
    public static class DatabaseConfig
    {
        public static void AddDatabaseConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddDbContext<QuestionsContext>(options =>
                options.UseSqlServer(services.GetConnectionString(nameof(QuestionsContext))));

            services.AddScoped<IUnitOfWork, UnitOfWork<QuestionsContext>>();
        }
    }
}
