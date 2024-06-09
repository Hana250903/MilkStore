namespace MilkStoreV4.DTOs
{
    public class VoucherDTO
    {
        public int VoucherId { get; set; }

        public string Title { get; set; } = null!;

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public double Discount { get; set; }

        public int Quantity { get; set; }

        public string Status { get; set; } =null!;
    }
    public class CreateVoucherDTO
    {
        public string Title { get; set; } =null !;

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public double Discount { get; set; }

        public int Quantity { get; set; }

        public string Status { get; set; } = null !;
    }
    public class UpdateVoucherDTO
    {
        public string Title { get; set; } = null!;

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public double Discount { get; set; }

        public int Quantity { get; set; }

        public string Status { get; set; } = null!;
    }
}
