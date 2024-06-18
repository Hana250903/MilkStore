using MilkStoreV4.DTOs;
using Repositories.Models;

namespace MilkStoreV4.Mappers
{
    public static class CommentMapper
    {
        public static CommentDTO ToCommentDTO (this Comment comment)
        {
            return new CommentDTO
            {
                CommentId = comment.CommentId,
                MemberId = comment.MemberId,
                DateCreate = comment.DateCreate.ToString("G"),
                Content = comment.Content,
                Rate = comment.Rate,
                MilkId = comment.MilkId,
            };
        }

        public static Comment ToCommentFromCreateDTO (this CreateCommentDTO comment)
        {
            return new Comment
            {
                MemberId = comment.MemberId,
                DateCreate = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time")),
                Content = comment.Content,
                Rate = comment.Rate,
                MilkId = comment.MilkId,
            };
        }

        public static void ToCommentFromUpdateDTO (this UpdateCommentDTO commentDTO, Comment comment)
        {
            comment.Content = commentDTO.Content;
            comment.Rate = commentDTO.Rate;
        }
    }
}
