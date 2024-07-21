namespace MilkStoreV4.DTOs
{
    public class VoucherStatusDTO
    {
        public int VoucherStatusId { get; set; }

        public string VoucherStatus { get; set; } = null!;
    }

    public class CreateVoucherStatusDTO
    {
        public string VoucherStatus { get; set; } = null!;
    }

    public class UpdateVoucherStatusDTO
    {
        public string VoucherStatus { get; set; } = null!;
    }
}
