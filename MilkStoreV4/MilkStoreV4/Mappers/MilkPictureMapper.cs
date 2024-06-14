using MilkStoreV4.DTOs;
using Repositories.Models;

namespace MilkStoreV4.Mappers
{
    public static class MilkPictureMapper
    {
        public static MilkPictureDTO ToMilkPictureDTO(this MilkPicture milkPictureDTO)
        {
            return new MilkPictureDTO
            {
                MilkPictureId = milkPictureDTO.MilkPictureId,
                MilkId = milkPictureDTO.MilkId,
                Picture = milkPictureDTO.Picture,
            };
        }

        public static MilkPicture ToMilkPictureFromCreateDTO(this CreateMilkPictureDTO milkPictureDTO)
        {
            return new MilkPicture
            {
                MilkId = milkPictureDTO.MilkId,
                Picture = milkPictureDTO.Picture,
            };
        }

        public static void ToMilkPictureFromUpdateDTO(UpdateMilkPictureDTO milkPictureDTO, MilkPicture milkPicture)
        {
            milkPicture.Picture = milkPictureDTO.Picture;
        }
    }
}
