namespace MilkStoreV4.DTOs
{
    public class MilkDTO
    {
        public int MilkId { get; set; }

        public string MilkName { get; set; } = string.Empty;

        public int BrandId { get; set; }

        public int Capacity { get; set; }

        public int MilkTypeId { get; set; }

        public string AppropriateAge { get; set; } = string.Empty;

        public string StorageInstructions { get; set; } = string.Empty;

        public double Price { get; set; }

        public double Discount { get; set; }
    }

    public class CreateMilkDTO
    {
        public string MilkName { get; set; } = string.Empty;

        public int BrandId { get; set; }

        public int Capacity { get; set; }

        public int MilkTypeId { get; set; }

        public string AppropriateAge { get; set; } = string.Empty;

        public string StorageInstructions { get; set; } = string.Empty;

        public double Price { get; set; }

        public double Discount { get; set; }
    }

    public class UpdateMilkDTO
    {
        public string MilkName { get; set; } = string.Empty;

        public int BrandId { get; set; }

        public int Capacity { get; set; }

        public int MilkTypeId { get; set; }

        public string AppropriateAge { get; set; } = string.Empty;

        public string StorageInstructions { get; set; } = string.Empty;

        public double Price { get; set; }

        public double Discount { get; set; }
    }
}
