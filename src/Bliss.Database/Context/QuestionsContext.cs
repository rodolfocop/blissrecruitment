using Microsoft.EntityFrameworkCore;

namespace Bliss.Database.Context
{
    public sealed class QuestionsContext : DbContext
    {
        public QuestionsContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            AddMappingsDynamically(builder);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        private static void AddMappingsDynamically(ModelBuilder builder)
        {
            var currentAssembly = typeof(QuestionsContext).Assembly;
            var efMappingTypes = currentAssembly.GetTypes().Where(t =>
                t.FullName != null && t.FullName.StartsWith("Bliss.Database.Mapping.") && t.FullName.EndsWith("Mapping"));

            foreach (var map in efMappingTypes.Select(Activator.CreateInstance))
            {
                builder.ApplyConfiguration((dynamic)map!);
            }
        }
    }
}
