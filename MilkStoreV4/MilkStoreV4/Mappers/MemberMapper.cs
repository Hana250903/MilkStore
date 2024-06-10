using MilkStoreV4.DTOs;
using Repositories.Models;

namespace MilkStoreV4.Mappers
{
    public static class MemberMapper
    {
        public static MemberDTO ToMemberDTO (this Member member)
        {
            return new MemberDTO
            {
                MemberId = member.MemberId,
                UserId = member.UserId,
                Desciption = member.Desciption,
            };
        }
        public static Member ToMemberFromCreateDTO (this CreateMemberDTO member)
        {
            return new Member
            { 
                UserId = member.UserId,
                Desciption = member.Desciption,
            };
        }
        public static void ToMemberFromUpdateDTO(this UpdateMemberDTO memberDTO, Member member)
        {
            member.Desciption = memberDTO.Desciption;
        }
    }
}
