using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeerTap.Transport
{
    [Table("Office")]
    public class OfficeData
    {
        public OfficeData()
        {
            this.OfficeInfos = new List<OfficeInfoData>();
        }

        [Key]
        public int Id { get; set; }
        public string OfficeName { get; set; }

        [ForeignKey("OfficeId")]
        public ICollection<OfficeInfoData> OfficeInfos { get; set; }
    }
}
