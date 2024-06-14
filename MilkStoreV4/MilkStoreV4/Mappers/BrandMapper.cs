using MilkStoreV4.DTOs;
using Repositories.Models;

namespace MilkStoreV4.Mappers
{
    public static class BrandMapper
    {
        public static BrandDTO ToBrandDTO (this Brand brandDTO)
        {
            return new BrandDTO
            {
                BrandId = brandDTO.BrandId,
                BrandName = brandDTO.BrandName,
            };
        }

        public static Brand ToBrandFromCreateDTO(this CreateBrandDTO brandDTO)
        {
            return new Brand
            {
                BrandName = brandDTO.BrandName,
            };
        }

        public static void ToBrandFromUpdateDTO(this UpdateBrandDTO brandDTO, Brand brand)
        {
            brand.BrandName = brandDTO.BrandName;
        }
    }
}
