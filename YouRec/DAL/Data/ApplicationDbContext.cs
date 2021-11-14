using DAL.Helper;
using DAL.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.Migrate();
        }

        public virtual DbSet<Recommend> Recommends { get; set; }

        public virtual DbSet<Tag> Tags { get; set; }

        public virtual DbSet<Comment> Comments { get; set; }

        public virtual DbSet<Group> Groups { get; set; }

        public virtual DbSet<Images> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Seed();
            base.OnModelCreating(builder);
        }
    }
}
