using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteka
{
    public class BazaContext : DbContext
    {
        public BazaContext(DbContextOptions options) : base(options)
        {
        }

        protected BazaContext()
        {
        }

        public virtual DbSet<Pozycja> Pozycje { get; set; }
        public virtual DbSet<Historia> Historia { get; set; }
        public virtual DbSet<Rodzaj> Rodzaje { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           // optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=BibliotekaDb;Integrated Security = True");
            base.OnConfiguring(optionsBuilder);
        }
        
    }
}
