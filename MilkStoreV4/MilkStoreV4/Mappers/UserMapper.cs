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
                DateOfBirth = ParseDate(user.DateOfBirth),
                Gender = user.Gender,
                Address = user.Address,
                RoleId = 3,
                ProfilePicture = user.ProfilePicture,
                DateCreate = dateCreateInUtc7,
            };
        }
        public static void ToUserFromUpdateDTO(this UpdateUserDTO userDTO, User user)
        {

            user.UserName = userDTO.UserName;
            user.Phone = userDTO.Phone;
            user.DateOfBirth = ParseDate(userDTO.DateOfBirth);
            user.Gender = userDTO.Gender;
            user.Address = userDTO.Address;
            user.ProfilePicture = userDTO.ProfilePicture;

        }

        public static DateTime ParseDate(string dateString)
        {
            string[] formats = { "yyyy-MM-dd", "yyyy-MM-dd HH:mm" };
            DateTime date;
            if (DateTime.TryParseExact(dateString, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
            {
                return date;
            }
            throw new FormatException($"String '{dateString}' was not recognized as a valid DateTime.");
        }
    }
}
