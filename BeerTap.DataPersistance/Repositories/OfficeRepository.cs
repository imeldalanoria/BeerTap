using System.Data.Entity;
using BeerTap.Transport;

namespace BeerTap.DataPersistance.Repositories
{
    public class OfficeRepository : RepositoryBase<OfficeData>
    {
        public OfficeRepository(DbContext unitOfWork):base(unitOfWork)
        {
            
        }    
    }
}
