using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BeerTap.DAL
{
    public class OfficeInfoRepository : RepositoryBase<OfficeInfoData>
    {
        public OfficeInfoRepository(DbContext unitOfWork) : base(unitOfWork)
        {
        }

        public virtual List<OfficeInfoData> GetDataByOfficeId(int officeId)
        {
            return base.Get(c => c.OfficeId == officeId);
        }

        public virtual OfficeInfoData GetDataByOfficeInfoId(int officeId,int officeInfoId)
        {
            return base.Get(c => c.OfficeId == officeId && c.Id == officeInfoId).FirstOrDefault();
        }
    }
}
