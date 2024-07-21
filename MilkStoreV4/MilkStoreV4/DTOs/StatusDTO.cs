namespace MilkStoreV4.DTOs
{
    public class StatusDTO
    {
        public int StatusId { get; set; }
        public string Status { get; set; } = null!;
    }

    public class CreateStatusDTO
    {
        public string Status { get; set; } = null!;
    }

    public class UpdateStatusDTO
    {
        public string Status { get; set; } = null!;
    }
}
