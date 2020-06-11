using BibliotekaAuthDb.Entities;
//using BibliotekaDb.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BibliotekaAuthDb
{
    public class AuthDatabaseContext : IdentityDbContext<AppUser>
    {
        public AuthDatabaseContext(DbContextOptions options) : base(options)
        {
        }

        protected AuthDatabaseContext()
        {
        }

        //public virtual DbSet<Pozycja> Pozycje { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
