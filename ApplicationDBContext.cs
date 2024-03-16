using Microsoft.EntityFrameworkCore;
using SampleDockerApp;

namespace SampleDockerApp
{
    public class ApplicationDBContext: DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
        : base(options)
        {
        }

        public DbSet<User> User => Set<User>();
    }
}
