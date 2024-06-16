using MilkStoreV4.DTOs;
using Repositories.Models;

namespace MilkStoreV4.Mappers
{
    public static class CommentPictureMapper
    {
        public static CommentPictureDTO ToCommentPictureDTO(this Commentpicture commentpicture)
        {
            return new CommentPictureDTO
            {
                CommentPictureId = commentpicture.CommentPictureId,
                CommentId = commentpicture.CommentPictureId,
                Picture = commentpicture.Picture,
            };
        }

        public static Commentpicture ToCommentPictureFromCreateDTO(this CreateCommentPictureDTO commentpictureDTO)
        {
            return new Commentpicture
            {
                CommentId = commentpictureDTO.CommentId,
                Picture = commentpictureDTO.Picture,
            };
        }

        public static void ToCommentPictureFromUpdateDTO(this UpdateCommentPictureDTO commentpictureDTO, Commentpicture commentpicture)
        {
            commentpicture.Picture = commentpictureDTO.Picture;
        }
    }
}
