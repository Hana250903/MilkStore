namespace MilkStoreV4.DTOs
{
    public class MemberDTO
    {
        public int MemberId { get; set; }

        public int UserId { get; set; }

        public string? Desciption { get; set; }
        
        public virtual ICollection<OrderDTO> Orders { get; set; } = new List<OrderDTO>();
    }

    public class CreateMemberDTO
    {
        public int UserId { get; set; }

        public string? Desciption { get; set; }
    }
    public class UpdateMemberDTO 
    {
        public string? Desciption { get; set; }


    }
}
