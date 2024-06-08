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
                Content = comment.Content,
                Picture = comment.Picture,
                Rate = comment.Rate,
                MilkId = comment.MilkId,
            };
        }

        public static Comment ToCommentFromCreateDTO (this CreateCommentDTO comment)
        {
            return new Comment
            {
                MemberId = comment.MemberId,
                DateCreate = comment.DateCreate,
                Content = comment.Content,
                Picture = comment.Picture,
                Rate = comment.Rate,
                MilkId = comment.MilkId,
            };
        }

        public static Comment ToCommentFromUpdateDTO (this UpdateCommentDTO comment)
        {
            return new Comment
            {
                Content = comment.Content,
                Picture = comment.Picture,
                Rate = comment.Rate,
            };
        }
    }
}
