using AutoMapper;
using Mango.Services.CoupanAPI.Models;
using Mango.Services.CoupanAPI.Models.Dto;

namespace Mango.Services.CoupanAPI
{
    public class MappingConfig
    {public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CouponDto, Coupon>();
                config.CreateMap<Coupon, CouponDto>();
            });
            return mappingConfig;
        }
    }
}
