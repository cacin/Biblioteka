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

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           // optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=BibliotekaDb;Integrated Security = True");
            base.OnConfiguring(optionsBuilder);
        }*/

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }
}
