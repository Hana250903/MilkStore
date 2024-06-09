namespace MilkStoreV4.DTOs
{
    public class UserDTO
    {
        public int UserId { get; set; }

        public string UserName { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public DateTime DateOfBirth { get; set; }

        public string Gender { get; set; } = null!;

        public string Address { get; set; } = null!;

        public int RoleId { get; set; }

        public string ProfilePicture { get; set; } = null!;

        public DateTime DateCreate { get; set; } 
    }

    public class CreateUserDTO
    {
        public string UserName { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public DateTime DateOfBirth { get; set; }

        public string Gender { get; set; } = null!;

        public string Address { get; set; } = null!;

        public int RoleId { get; set; }

        public string ProfilePicture { get; set; } = null!;

        public DateTime DateCreate { get; set; }
    }

    public class UpdateUserDTO
    {
        public string UserName { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public DateTime DateOfBirth { get; set; }

        public string Gender { get; set; } = null!;

        public string Address { get; set; } = null!;

        public int RoleId { get; set; }

        public string ProfilePicture { get; set; } = null!;

        public DateTime DateCreate { get; set; }
    }
}
