using MilkStoreV4.DTOs;
using Repositories.Models;

namespace MilkStoreV4.Mappers
{
    public static class AdminMapper
    {
        public static AdminDTO ToAdminDTO(this Admin admin)
        {
            return new AdminDTO
            {
                AdminId = admin.AdminId,
                UserId = admin.UserId,
                Desciption = admin.Desciption,
            };
        }
        public static Admin ToAdminFromCreateDTO(this CreateAdminDTO admin)
        {
            return new Admin
            {
                UserId = admin.UserId,
                Desciption = admin.Desciption,
            };
        }
        public static void ToAdminFromUpdateDTO(this UpdateAdminDTO adminDTO, Admin admin)
        { 
                admin.Desciption = adminDTO.Desciption;
        }
    }
}
