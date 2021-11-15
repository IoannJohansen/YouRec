using DAL.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DAL.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<Recommend> Recommends { get; set; }

        public virtual DbSet<Tag> Tags { get; set; }

        public virtual DbSet<Comment> Comments { get; set; }

        public virtual DbSet<Group> Groups { get; set; }

        public virtual DbSet<Images> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedGroups(builder);
            SeedRoles(builder);
        }

        private void SeedGroups(ModelBuilder builder)
        {
            builder.Entity<Group>().HasData(new Group { Id = 1, GroupName = "Games" }, new Group { Id = 2, GroupName = "Movies" }, new Group { Id = 3, GroupName = "Smoking" }, new Group { Id = 4, GroupName = "Papaya" });
        }

        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "User" }, new IdentityRole { Name = "Admin" });
        }
    }
}
