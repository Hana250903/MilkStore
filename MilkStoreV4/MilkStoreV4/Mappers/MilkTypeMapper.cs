using MilkStoreV4.DTOs;
using Repositories.Models;

namespace MilkStoreV4.Mappers
{
    public static class MilkTypeMapper
    {
        public static MilkTypeDTO ToMilkTypeDTO(this MilkTypeDTO milkTypeDTO)
        {
            return new MilkTypeDTO
            {
                MilkTypeId = milkTypeDTO.MilkTypeId,
                TypeName = milkTypeDTO.TypeName,
            };
        }

        public static MilkType ToMilkTypeFromCreateDTO(this CreateMilkTypeDTO milkTypeDTO)
        {
            return new MilkType
            {
                TypeName = milkTypeDTO.TypeName,
            };
        }

        public static void ToMilkTypeFromUpdateDTO(UpdateMilkTypeDTO milkTypeDTO, MilkType milkType)
        {
            milkType.TypeName = milkTypeDTO.TypeName;
        }
    }
}
