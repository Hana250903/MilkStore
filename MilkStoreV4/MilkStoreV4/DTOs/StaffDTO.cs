namespace MilkStoreV4.DTOs
{
    public class StaffDTO
    {
        public int StaffId { get; set; }

        public int UserId { get; set; }

        public string Desciption { get; set; } = null!;
    }
    public class CreateStaffDTO
    {
        public int StaffId { get; set; }

        public int UserId { get; set; }

        public string Desciption { get; set; } =null!;
    }
    public class UpdateStaffDTO
    {
        public int StaffId { get; set; }

        public int UserId { get; set; }

        public string Desciption { get; set; } =null!;
    }
}
