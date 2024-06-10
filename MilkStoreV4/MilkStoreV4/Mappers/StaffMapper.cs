using MilkStoreV4.DTOs;
using Repositories.Models;

namespace MilkStoreV4.Mappers
{
    public static class StaffMapper
    {
        public static StaffDTO ToStaffDTO(this Staff staff)
        {
            return new StaffDTO
            {
                StaffId = staff.StaffId,
                UserId = staff.UserId,
                Desciption = staff.Desciption,
            };
        }
        public static Staff ToStaffFromCreateDTO (this CreateStaffDTO staff)
        {
            return new Staff
            {
                UserId = staff.UserId,
                Desciption = staff.Desciption,
            };
        }
        public static void ToStaffFromUpdateDTO(this UpdateStaffDTO staffDTO, Staff staff)
        {
            staff.Desciption = staffDTO.Desciption;
        }
    }
}
