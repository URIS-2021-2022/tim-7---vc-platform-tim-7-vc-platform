using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace VirtoCommerce.Platform.Security.Repositories
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<SecurityDbContext>
    {
        public IConfiguration Configuration { get; }

        public DesignTimeDbContextFactory(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public SecurityDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<SecurityDbContext>();

            builder.UseSqlServer(Configuration.GetConnectionString("VirtoCommerce"));
            builder.UseOpenIddict();
            return new SecurityDbContext(builder.Options);
        }
    }
}
