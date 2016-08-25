using System.Data.Entity;

namespace BeerTap.DAL
{
    public class OfficeRepository : RepositoryBase<OfficeData>
    {
        public OfficeRepository(DbContext unitOfWork):base(unitOfWork)
        {
            
        }    
    }
}
