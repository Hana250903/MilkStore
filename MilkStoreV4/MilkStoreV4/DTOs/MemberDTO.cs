namespace MilkStoreV4.DTOs
{
    public class MemberDTO
    {
        public int MemberId { get; set; }

        public int UserId { get; set; }

        public string Desciption { get; set} = null!;
    }

    public class CreateMemberDTO
    {
        public int MemberId { get; set; }

        public int UserId { get; set; }

        public string Desciption { get; set; } = null!;
    }
    public class UpdateMemberDTO 
    {
        public int MemberId { get; set; }

        public int UserId { get; set; }

        public string Desciption { get; set; } =null!;


    }
}
