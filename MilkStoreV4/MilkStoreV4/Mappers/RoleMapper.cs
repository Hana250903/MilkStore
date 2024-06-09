using MilkStoreV4.DTOs;
using Repositories.Models;

namespace MilkStoreV4.Mappers
{
    public static class RoleMapper
    {
        public static RoleDTO ToRoleDTO(this Role role)
        {
            return new RoleDTO
            {
                RoleId = role.RoleId,
                RoleName = role.RoleName,
            };
        }
        public static Role ToRoleFromCreateDTO(this CreateRoleDTO role)
        {
            {
                return new Role
                {
                    RoleName = role.RoleName,
                };
            }

        }
        public static Role ToRoleFromUpdateDTO(this UpdateRoleDTO role)
        {
            return new Role
            {
                RoleName = role.RoleName,
            };
        }
    }
}
