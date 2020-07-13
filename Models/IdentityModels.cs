using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PersonalEstore.cs.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string Address { get; set; }
        [Required]
        public bool IsAdmin { get; set; }

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
            : base("ApplicationDbContext", throwIfV1Schema: false)
        {
            //this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Cosmatics> Cosmatics { get; set; }
        public DbSet<HomeAppliances> HomeAppliances { get; set; }
        public DbSet<Manufacturer> Manufacturer { get; set; }
        public DbSet<Clothing> MenClothing { get; set; }
        public DbSet<MobilePhones> MobilePhones { get; set; }
        public DbSet<Category> Category { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}