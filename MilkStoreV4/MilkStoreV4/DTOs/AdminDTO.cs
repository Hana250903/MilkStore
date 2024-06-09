namespace MilkStoreV4.DTOs
{
    public class AdminDTO
    {
        public int AdminId { get; set; }

        public int UserId { get; set; }

        public string Desciption { get; set; } = null!;

    }

    public class CreateAdminDTO 
    {
        public int UserId { get; set; }

        public string Desciption { get; set; } = null!;
    }

    public class UpdateAdminDTO
    {
        public string Desciption { get; set; } = null!;
    }
}
