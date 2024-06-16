namespace MilkStoreV4.DTOs
{
    public class CommentPictureDTO
    {
        public int CommentPictureId { get; set; }

        public int CommentId { get; set; }

        public string Picture { get; set; } = null!;
    }
    public class CreateCommentPictureDTO
    {
        public int CommentId { get; set; }

        public string Picture { get; set; } = null!;
    }

    public class UpdateCommentPictureDTO
    {
        public string Picture { get; set; } = null!;
    }
}
