using BeerTap.Model;
using BeerTap.Transport;

namespace BeerTap.WebApi.Infrastructure
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            AutoMapper.Mapper.CreateMap<OfficeInfoData, OfficeInfo>()
                .ForMember(c => c.Id, b => b.MapFrom(c => c.Id))
                .ForMember(c => c.OfficeId, b => b.MapFrom(c => c.OfficeId))
                .ForMember(c => c.Beertype, b => b.MapFrom(c => c.Beertype))
                .ForMember(c => c.Milliliter, b => b.MapFrom(c => c.Milliliter));

            AutoMapper.Mapper.CreateMap<OfficeData, Office>()
                .ForMember(c => c.Id, b => b.MapFrom(c => c.Id))
                .ForMember(c => c.OfficeName, b => b.MapFrom(c => c.OfficeName));        

        }
    }
}