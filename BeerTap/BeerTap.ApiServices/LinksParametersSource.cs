namespace BeerTap.ApiServices
{
    /// <summary>
    /// The class is used to pass additional parameters to hypermedia links definitions in resource specifications.
    /// </summary>
    public class LinksParametersSource
    {
        public LinksParametersSource(int officeInfoId, int officeId)
        {
            OfficeId = officeId;
            OfficeInfoId = officeInfoId;
        }

        public int OfficeId { get; private set; }
        public int OfficeInfoId { get; set; }
    }
}