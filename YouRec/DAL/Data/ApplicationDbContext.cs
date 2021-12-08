using DAL.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DAL.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration) : base(options)
        {
            this.Configuration = configuration;
            Database.Migrate();
        }

        private IConfiguration Configuration;

        public virtual DbSet<Recommend> Recommends { get; set; }

        public virtual DbSet<Tag> Tags { get; set; }

        public virtual DbSet<Comment> Comments { get; set; }

        public virtual DbSet<Group> Groups { get; set; }

        public virtual DbSet<Image> Images { get; set; }

        public virtual DbSet<Rating> Ratings { get; set; }

        public virtual DbSet<RecommendTag> RecommendTags { get; set; }

        public virtual DbSet<Like> Likes { get; set; }

        //public virtual DbSet<AppUser> AspNetUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedGroups(builder);
            SeedRoles(builder);
            SeedUsers(builder);
        }

        private void SeedGroups(ModelBuilder builder)
        {
            builder.Entity<Group>().HasData(new Group { Id = 1, GroupName = "Games" }, new Group { Id = 2, GroupName = "Movies" }, new Group { Id = 3, GroupName = "Anime" }, new Group { Id = 4, GroupName = "Sport" }, new Group { Id = 5, GroupName = "Technique"} , new Group { Id = 6, GroupName = "Books"} , new Group { Id = 7, GroupName = "Food" } );
        }

        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "User", NormalizedName = "USER", Id = Configuration["USERRoleID"] }, new IdentityRole { Name = "Admin", NormalizedName = "ADMIN", Id = Configuration["ADMINRoleID"] });
        }

        private void SeedUsers(ModelBuilder builder)
        {
            var passwordHasher = new PasswordHasher<AppUser>();
            var admin = new AppUser { Email = Configuration["ADMINEmail"], NormalizedEmail = Configuration["ADMINEmail"].ToUpper(), UserName = "Admin", PasswordHash = passwordHasher.HashPassword(null, Configuration["ADMINPassword"]) };
            builder.Entity<AppUser>().HasData(admin);
            
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string> { RoleId = Configuration["ADMINRoleID"], UserId = admin.Id });
        }
    }
}
