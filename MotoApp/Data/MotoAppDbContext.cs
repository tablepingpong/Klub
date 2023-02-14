using Microsoft.EntityFrameworkCore;
using MotoApp.Entities;
using MotoApp.Entitis;

namespace MotoApp.Data
{
    public class MotoAppDbContext : DbContext
    {
        public DbSet<Athlete> Athletes => Set<Athlete>();

        //public DbSet<BusinessPartner> BusinessPartners => Set<BusinessPartner>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase("StorageAppDb");
        }

    }
}
