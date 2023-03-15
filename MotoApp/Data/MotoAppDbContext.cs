using Microsoft.EntityFrameworkCore;

using MotoApp.Entities;
using MotoApp.Entitis;

namespace MotoApp.Data;

    public class MotoAppDbContext : DbContext
    {
        public DbSet<Athlete> Athletes => Set<Athlete>();

        public DbSet<Trener> Treners => Set<Trener>();

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    optionsBuilder.UseInMemoryDatabase(@"Server=(localdb)\mssqllocaldb;Database=MotoAppDB;Trusted_connection=True;");
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server = (localdb)\MSSQLLocalDB;Database=MotoAppDB;Trusted_connection=True;");
        }
    }

