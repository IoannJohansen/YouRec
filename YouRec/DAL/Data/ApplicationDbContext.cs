using DAL.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DAL.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration) : base(options)
        {
            this.Configuration = configuration;
            Database.EnsureCreated();
        }

        private IConfiguration Configuration;

        public virtual DbSet<Recommend> Recommends { get; set; }

        public virtual DbSet<Tag> Tags { get; set; }

        public virtual DbSet<Comment> Comments { get; set; }

        public virtual DbSet<Group> Groups { get; set; }

        public virtual DbSet<Images> Images { get; set; }

        public virtual DbSet<Rating> Ratings { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedGroups(builder);
            SeedRoles(builder);
            SeedUsers(builder);
        }

        private void SeedGroups(ModelBuilder builder)
        {
            builder.Entity<Group>().HasData(new Group { Id = 1, GroupName = "Games" }, new Group { Id = 2, GroupName = "Movies" }, new Group { Id = 3, GroupName = "Smoking" }, new Group { Id = 4, GroupName = "Papaya" });
        }

        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "User", NormalizedName = "USER", Id = Configuration["USER:RoleID"] }, new IdentityRole { Name = "Admin", NormalizedName = "ADMIN", Id = Configuration["ADMIN:RoleID"] });
        }

        private void SeedUsers(ModelBuilder builder)
        {
            var passwordHasher = new PasswordHasher<IdentityUser>();
            var admin = new IdentityUser { Email = Configuration["ADMIN:Email"], NormalizedEmail = Configuration["ADMIN:Email"].ToUpper(), UserName = "Admin", PasswordHash = passwordHasher.HashPassword(null, Configuration["ADMIN:Password"]) };
            builder.Entity<IdentityUser>().HasData(admin);
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string> { RoleId = Configuration["ADMIN:RoleID"], UserId = admin.Id });
        }
    }
}
