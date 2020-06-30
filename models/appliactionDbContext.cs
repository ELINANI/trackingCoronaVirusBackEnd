using Microsoft.EntityFrameworkCore;

namespace trackingCoronaVirusBackEnd2.models
{
    public class appliactionDbContext:DbContext
    {
          public appliactionDbContext(DbContextOptions<appliactionDbContext> options):base(options)
        {       
        }
        public DbSet<Quartier> Quartiers {get;set;}
        public DbSet<Niveau> Niveaux {get;set;}
        public DbSet<Hopitale> Hopitaux {get;set;}
        public DbSet<Client> Clients {get;set;}
        public DbSet<Contamination> contaminations {get;set;}
    }
}