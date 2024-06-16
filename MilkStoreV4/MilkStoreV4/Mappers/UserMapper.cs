using MilkStoreV4.DTOs;
using Repositories.Models;

namespace MilkStoreV4.Mappers
{
    public static class UserMapper
    {
        public static UserDTO ToUserDTO(this User user)
        {
            return new UserDTO
            {
                UserId = user.UserId,
                UserName = user.UserName,
                Phone = user.Phone,
                DateOfBirth = user.DateOfBirth.ToString("yyyy-MM-dd"),
                Gender = user.Gender,
                Address = user.Address,
                RoleId = user.RoleId,
                ProfilePicture = user.ProfilePicture,
                DateCreate = user.DateCreate.ToString("yyyy-MM-dd HH:mm"),
            };
        }
        public static User ToUserFromCreateDTO(this CreateUserDTO user)
        {
            var utcNow = DateTime.UtcNow;
            var timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
            var dateCreateInUtc7 = TimeZoneInfo.ConvertTimeFromUtc(utcNow, timeZoneInfo);

            return new User
            {
                UserName = user.UserName,
                Phone = user.Phone,
                DateOfBirth = user.DateOfBirth,
                Gender = user.Gender,
                Address = user.Address,
                RoleId = user.RoleId,
                ProfilePicture = user.ProfilePicture,
                DateCreate = dateCreateInUtc7,
            };
        }
        public static void ToUserFromUpdateDTO(this UpdateUserDTO userDTO, User user)
        {

            user.UserName = userDTO.UserName;
            user.Phone = userDTO.Phone;
            user.DateOfBirth = userDTO.DateOfBirth;
            user.Gender = userDTO.Gender;
            user.Address = userDTO.Address;
            user.ProfilePicture = userDTO.ProfilePicture;

        }
    }
}
