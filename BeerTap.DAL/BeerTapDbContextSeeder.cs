using System.Collections.Generic;
using System.Data.Entity;

namespace BeerTap.DAL
{
    public class BeerTapDbContextSeeder : DropCreateDatabaseIfModelChanges<BeerTapDbContext>
    {

        protected override void Seed(BeerTapDbContext context)
        {

            OfficeData office1 = new OfficeData()
            {
                OfficeName = "Vancouver",
                OfficeInfos = new List<OfficeInfoData>()
                {
                    new OfficeInfoData(){OfficeId = 1, Beertype = "Molson", Milliliter = 2365},
                    new OfficeInfoData(){OfficeId = 1, Beertype = "Labatt", Milliliter = 2365}
                }
            };
            OfficeData office2 = new OfficeData()
            {
                OfficeName = "Regina",
                OfficeInfos = new List<OfficeInfoData>()
                {
                    new OfficeInfoData(){OfficeId = 2, Beertype = "Sleeman", Milliliter = 2365},
                    new OfficeInfoData(){OfficeId = 2, Beertype = "Moosehead", Milliliter = 2365}
                }
            };
            OfficeData office3 = new OfficeData()
            {
                OfficeName = "Winnipeg",
                OfficeInfos = new List<OfficeInfoData>()
                {
                    new OfficeInfoData(){OfficeId = 3, Beertype = "Bud Light", Milliliter = 2365},
                    new OfficeInfoData(){OfficeId = 3, Beertype = "Busch", Milliliter = 2365}
                }
            };
            OfficeData office4 = new OfficeData()
            {
                OfficeName = "Davidson (NC)",
                OfficeInfos = new List<OfficeInfoData>()
                {
                    new OfficeInfoData(){OfficeId = 4, Beertype = "Bass", Milliliter = 2365}
                }
            };
            OfficeData office5 = new OfficeData()
            {
                OfficeName = "Manila Philippines",
                OfficeInfos = new List<OfficeInfoData>()
                {
                    new OfficeInfoData(){OfficeId = 5, Beertype = "Red Horse", Milliliter = 2365}
                }
            };
            OfficeData office6 = new OfficeData()
            {
                OfficeName = "Sydney Australia",
                OfficeInfos = new List<OfficeInfoData>()
                {
                    new OfficeInfoData(){OfficeId = 6, Beertype = "Heineken", Milliliter = 2365}
                }
            };

            context.Offices.Add(office1);
            context.Offices.Add(office2);
            context.Offices.Add(office3);
            context.Offices.Add(office4);
            context.Offices.Add(office5);
            context.Offices.Add(office6);
            base.Seed(context);

        }
    }
}
