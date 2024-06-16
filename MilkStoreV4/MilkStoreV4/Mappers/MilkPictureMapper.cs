using MilkStoreV4.DTOs;
using Repositories.Models;

namespace MilkStoreV4.Mappers
{
    public static class MilkPictureMapper
    {
        public static MilkPictureDTO ToMilkPictureDTO(this Milkpicture milkPicture)
        {
            return new MilkPictureDTO
            {
                MilkPictureId = milkPicture.MilkPictureId,
                MilkId = milkPicture.MilkId,
                Picture = milkPicture.Picture,
            };
        }

        public static Milkpicture ToMilkPictureFromCreateDTO(int milkId, CreateMilkPictureDTO milkPictureDTO)
        {
            return new Milkpicture
            {
                MilkId = milkId,
                Picture = milkPictureDTO.Picture,
            };
        }

        public static void ToMilkPictureFromUpdateDTO(UpdateMilkPictureDTO milkPictureDTO, Milkpicture milkPicture)
        {
            milkPicture.Picture = milkPictureDTO.Picture;
        }
    }
}
