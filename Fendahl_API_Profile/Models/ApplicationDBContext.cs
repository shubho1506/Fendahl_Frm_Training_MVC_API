using Microsoft.EntityFrameworkCore;

namespace Fendahl_API_Profile.Models
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<Profile> Profiles { get; set; }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }
    }
}
