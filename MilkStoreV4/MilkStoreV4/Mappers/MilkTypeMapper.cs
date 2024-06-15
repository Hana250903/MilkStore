using MilkStoreV4.DTOs;
using Repositories.Models;

namespace MilkStoreV4.Mappers
{
    public static class MilkTypeMapper
    {
        public static MilkTypeDTO ToMilkTypeDTO(this Milktype milkTypeDTO)
        {
            return new MilkTypeDTO
            {
                MilkTypeId = milkTypeDTO.MilkTypeId,
                TypeName = milkTypeDTO.TypeName,
            };
        }

        public static Milktype ToMilkTypeFromCreateDTO(this CreateMilkTypeDTO milkTypeDTO)
        {
            return new Milktype
            {
                TypeName = milkTypeDTO.TypeName,
            };
        }

        public static void ToMilkTypeFromUpdateDTO(UpdateMilkTypeDTO milkTypeDTO, Milktype milkType)
        {
            milkType.TypeName = milkTypeDTO.TypeName;
        }
    }
}
