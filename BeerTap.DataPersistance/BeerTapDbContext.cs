using System.Data.Entity;
using BeerTap.DataPersistance.Migrations;
using BeerTap.Transport;

namespace BeerTap.DataPersistance
{
    public class BeerTapDbContext : DbContext
    {
        public BeerTapDbContext() : base("DefaultConnectionString")
        {
        }

        public DbSet<OfficeData> Offices { get; set; }

        public DbSet<OfficeInfoData> OfficeInfos { get; set; }
    }
}
