using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerTap.DataPersistance;
using BeerTap.Transport;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new BeerTapDbContext())
            {

                // Create and save a new Blog 
                Console.Write("Enter a name: ");
                var name = Console.ReadLine();

                var officeName = new OfficeData() { OfficeName = name };
                db.Offices.Add(officeName);
                db.SaveChanges();

            }
        }
    }



}
