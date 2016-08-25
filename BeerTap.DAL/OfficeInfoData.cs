using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeerTap.DAL
{
    [Table("OfficeInfos")]
    public class OfficeInfoData
    {
        [Key]
        public int Id { get; set; }

        public int OfficeId { get; set; }

        public string Beertype { get; set; }

        public decimal Milliliter { get; set; }

       

    }
}
