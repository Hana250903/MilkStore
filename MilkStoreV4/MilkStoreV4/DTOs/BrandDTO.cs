namespace MilkStoreV4.DTOs
{
    public class BrandDTO
    {
        public int BrandId { get; set; }

        public string BrandName { get; set; } = string.Empty;
    }

    public class CreateBrandDTO
    {
        public string BrandName { get; set; } = string.Empty;
    }

    public class UpdateBrandDTO
    {
        public string BrandName { get; set; } = string.Empty;
    }
}
