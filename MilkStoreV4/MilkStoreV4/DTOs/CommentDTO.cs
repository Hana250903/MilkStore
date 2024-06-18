namespace MilkStoreV4.DTOs
{
    public class CommentDTO
    {
        public int CommentId { get; set; }
        public int MemberId { get; set; }
        public string DateCreate { get; set; } = null!;
        public string Content { get; set; } = null!;
        public double Rate { get; set; }
        public int MilkId { get; set; }
    }

    public class CreateCommentDTO
    {
        public int MemberId { get; set; }
        public string Content { get; set; } = null!;
        public double Rate { get; set; }
        public int MilkId { get; set; }
    }

    public class UpdateCommentDTO
    {
        public string Content { get; set; } = null!;
        public double Rate { get; set; }
    }
}
