using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PartyNeighbors.Data
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Party> Parties { get; set; }
        public DbSet<Neighborhood> Neighborhoods { get; set; }
        public DbSet<Resident> Residents { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<PartyItem> PartyItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<State> States { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Conventions
                .Remove<PluralizingTableNameConvention>();

            modelBuilder
                .Configurations
                .Add(new IdentityUserLoginConfiguration())
                .Add(new IdentityUserRoleConfiguration());

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Parties)
                .WithRequired(e => e.Category)
                .HasForeignKey(i => i.CategoryId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Neighborhood>()
                .HasMany(j => j.Residents)
                .WithRequired(e => e.Neighborhood)
                .HasForeignKey(i => i.NeighborhoodId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Neighborhood>()
                .HasMany(f => f.Parties)
                .WithRequired(e => e.Neighborhood)
                .HasForeignKey(i => i.NeighborhoodId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<State>()
                .HasMany(e => e.Neighborhoods)
                .WithRequired(e => e.State)
                .HasForeignKey(i => i.StateId)
                .WillCascadeOnDelete(false);
        }

    }

    public class IdentityUserLoginConfiguration : EntityTypeConfiguration<IdentityUserLogin>
    {
        public IdentityUserLoginConfiguration()
        {
            HasKey(iul => iul.UserId);
        }
    }

    public class IdentityUserRoleConfiguration : EntityTypeConfiguration<IdentityUserRole>
    {
        public IdentityUserRoleConfiguration()
        {
            HasKey(iur => iur.UserId);
        }
    }
}
