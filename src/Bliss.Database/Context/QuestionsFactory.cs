using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Bliss.Database.Context
{
    public sealed class QuestionsFactory : IDesignTimeDbContextFactory<QuestionsContext>
    {
        public QuestionsContext CreateDbContext(string[] args)
        {
            const string connectionString = "User ID=admin;Password=Password_1;Host=host.docker.internal;Port=15432;Database=bliss;";

            return new QuestionsContext(new DbContextOptionsBuilder<QuestionsContext>().UseSqlServer(connectionString).Options);
        }
    }
}
