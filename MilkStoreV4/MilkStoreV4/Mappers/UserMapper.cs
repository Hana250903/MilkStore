using MilkStoreV4.DTOs;
using Repositories.Models;
using System.Globalization;

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
                DateOfBirth = user.DateOfBirth.ToString("d"),
                Gender = user.Gender,
                Address = user.Address,
                RoleId = user.RoleId,
                ProfilePicture = user.ProfilePicture,
                DateCreate = user.DateCreate.ToString("G"),
            };
        }
        public static User ToUserFromCreateDTO(this CreateUserDTO user)
        {
            return new User
            {
                UserName = user.UserName,
                Phone = user.Phone,
                DateOfBirth = user.DateOfBirth,
                Gender = user.Gender,
                Address = user.Address,
                RoleId = 3,
                ProfilePicture = user.ProfilePicture,
                DateCreate = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time")),
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
