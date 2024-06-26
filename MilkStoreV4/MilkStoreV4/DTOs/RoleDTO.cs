﻿namespace MilkStoreV4.DTOs
{
    public class RoleDTO
    {
            public int RoleId { get; set; }

            public string RoleName { get; set; } = null!;
    }

    public class CreateRoleDTO
    {
        public string RoleName { get; set; } = null!;
    }

    public class UpdateRoleDTO
    {
        public string RoleName { get; set; } = null!;
    }
}
