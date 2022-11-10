using Bliss.Application.Questions;
using Bliss.Database.Repositories.Questions;
using DotNetCore.IoC;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Bliss.API.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddClassesMatchingInterfaces(
                typeof(IQuestionsFactory).Assembly,
                typeof(IQuestionsService).Assembly,
                typeof(IQuestionsRepository).Assembly
                );

        }
    }
}