using System.Data.Entity;

namespace BeerTap.DAL
{
    public class BeerTapDbContext : DbContext
    {
        public BeerTapDbContext(): base("Beertap") 
        {
           Database.SetInitializer(new BeerTapDbContextSeeder());
        }

        public DbSet<OfficeData> Offices { get; set; }

        public DbSet<OfficeInfoData> OfficeInfos { get; set; }
    }
}
