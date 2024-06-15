using MilkStoreV4.DTOs;
using Repositories.Models;

namespace MilkStoreV4.Mappers
{
    public static class MilkPictureMapper
    {
        public static MilkPictureDTO ToMilkPictureDTO(this Milkpicture milkPictureDTO)
        {
            return new MilkPictureDTO
            {
                MilkPictureId = milkPictureDTO.MilkPictureId,
                MilkId = milkPictureDTO.MilkId,
                Picture = milkPictureDTO.Picture,
            };
        }

        public static Milkpicture ToMilkPictureFromCreateDTO(this CreateMilkPictureDTO milkPictureDTO)
        {
            return new Milkpicture
            {
                MilkId = milkPictureDTO.MilkId,
                Picture = milkPictureDTO.Picture,
            };
        }

        public static void ToMilkPictureFromUpdateDTO(UpdateMilkPictureDTO milkPictureDTO, Milkpicture milkPicture)
        {
            milkPicture.Picture = milkPictureDTO.Picture;
        }
    }
}
