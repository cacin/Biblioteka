using BibliotekaWeb.HttpClient;
using Microsoft.EntityFrameworkCore;

namespace BibliotekaWeb
{
    public class BazaContextTemporary : DbContext
    {
        public BazaContextTemporary(DbContextOptions options) : base(options)
        {
        }

        /*protected BazaContext()
        {
        }*/

        public virtual DbSet<Pozycja> Pozycje { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }
}
