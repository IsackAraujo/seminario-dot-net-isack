using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace PW45S.Data
{
    public class SistemasTarefasDbContextFactory : IDesignTimeDbContextFactory<SistemasTarefasDbContext>
    {
        public SistemasTarefasDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.Development.json", optional: true)
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<SistemasTarefasDbContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            return new SistemasTarefasDbContext(optionsBuilder.Options);
        }
    }
}
