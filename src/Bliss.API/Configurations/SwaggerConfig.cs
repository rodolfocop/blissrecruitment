using Microsoft.OpenApi.Models;

namespace Bliss.API.Configurations
{
    public static class SwaggerConfig
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Bliss",
                    Description = "Bliss Recruitment API Swagger",
                    Contact = new OpenApiContact { Name = "Bliss", Email = "", Url = new Uri("https://blissrecruitmentapi.docs.apiary.io/") },
                    License = new OpenApiLicense { Name = "MIT", Url = new Uri("https://blissrecruitmentapi.docs.apiary.io/") }
                });
            });
        }

        public static void UseSwaggerSetup(this IApplicationBuilder app)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });
        }
    }
}
