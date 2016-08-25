namespace BeerTap.Model
{
    /// <summary>
    /// iQmetrix link relation names
    /// </summary>
    public static class LinkRelations
    {
        /// <summary>
        /// link relation to describe the Identity resource.
        /// </summary>
        public const string Office = "iq:Office";

        public const string OfficeInfo = "iq:OfficeInfo";
      
        public static class OfficeInfos
        {
            public const string Tap = "iq:Tap";

            public const string ReplaceKeg = "iq:ReplaceKeg";
        }
    }
}
