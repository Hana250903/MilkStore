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
                DateOfBirth = user.DateOfBirth,
                Gender = user.Gender,
                Address = user.Address,
                RoleId = user.RoleId,
                ProfilePicture = user.ProfilePicture,
                DateCreate = user.DateCreate,
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
                RoleId = user.RoleId,
                ProfilePicture = user.ProfilePicture,
                DateCreate = user.DateCreate,
            };
        }
        public static void ToUserFromUpdateDTO(this UpdateUserDTO userDTO, User user)
        {

            userDTO.UserName = user.UserName;
            userDTO.Phone = user.Phone;
            userDTO.DateOfBirth = user.DateOfBirth;
            userDTO.Gender = user.Gender;
            userDTO.Address = user.Address;
            userDTO.ProfilePicture = user.ProfilePicture;

        }
    }
}
