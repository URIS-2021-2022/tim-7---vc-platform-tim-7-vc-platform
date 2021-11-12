using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace VirtoCommerce.Platform.Data.Repositories
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<PlatformDbContext>
    {

        public IConfiguration Configuration { get; }

        public DesignTimeDbContextFactory(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public PlatformDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<PlatformDbContext>();

            builder.UseSqlServer(Configuration.GetConnectionString("VirtoCommerce"));

            return new PlatformDbContext(builder.Options);
        }
    }
}
