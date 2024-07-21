namespace MilkStoreV4.DTOs
{
    public class VoucherDTO
    {
        public int VoucherId { get; set; }

        public string Title { get; set; } = null!;

        public string StartDate { get; set; } = null!;

        public string EndDate { get; set; } = null!;

        public double Discount { get; set; }

        public int Quantity { get; set; }

        public int VoucherStatusId { get; set; }
    }
    public class CreateVoucherDTO
    {
        public string Title { get; set; } =null !;

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public double Discount { get; set; }

        public int Quantity { get; set; }

        public int VoucherStatusId { get; set; }
    }
    public class UpdateVoucherDTO
    {
        public string Title { get; set; } = null!;

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public double Discount { get; set; }

        public int Quantity { get; set; }

        public int VoucherStatusId { get; set; }
    }
}
