using Repositories.Models;

namespace MilkStoreV4.DTOs
{
    public class BrandDTO
    {
        public int BrandId { get; set; }

        public string BrandName { get; set; } = null!;

        public string? Picture { get; set; }
    }

    public class CreateBrandDTO
    {
        public string BrandName { get; set; } = string.Empty;
        public string? Picture { get; set; }
    }

    public class UpdateBrandDTO
    {
        public string BrandName { get; set; } = string.Empty;
        public string? Picture { get; set; }
    }
}
