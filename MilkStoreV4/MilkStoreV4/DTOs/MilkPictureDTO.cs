namespace MilkStoreV4.DTOs
{
    public class MilkPictureDTO
    {
        public int MilkPictureId { get; set; }

        public int MilkId { get; set; }

        public string Picture { get; set; } = string.Empty;
    }

    public class CreateMilkPictureDTO
    {
        public int MilkId { get; set; }

        public string Picture { get; set; } = string.Empty;
    }

    public class UpdateMilkPictureDTO
    {
        public string Picture { get; set; } = string.Empty;
    }
}
