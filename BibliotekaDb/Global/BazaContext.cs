using BibliotekaDb.Entities;
using Microsoft.EntityFrameworkCore;

namespace BibliotekaDb
{
    public class BazaContext : DbContext
    {
        public BazaContext(DbContextOptions options) : base(options)
        {
        }

        /*protected BazaContext()
        {
        }*/

        public virtual DbSet<Pozycja> Pozycje { get; set; }
        public virtual DbSet<Historia> Historia { get; set; }
        public virtual DbSet<Rodzaj> Rodzaje { get; set; }

      
        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.SeedEnumValues<Rodzaj, RodzajEnum>(e => e);
            builder.Entity<Pozycja>()
                .HasIndex(b => b.Uzytkownik)
                .HasName("Index_uzytkownik");
            base.OnModelCreating(builder);
        }

    }
}
