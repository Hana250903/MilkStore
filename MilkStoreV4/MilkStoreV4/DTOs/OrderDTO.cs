namespace MilkStoreV4.DTOs
{
    public class OrderDTO
    {
        public int OrderId { get; set; }

        public int MemberId { get; set; }

        public int? VoucherId { get; set; }

        public string DateCreate { get; set; } = null!;

        public double Amount { get; set; }

        public int StatusId { get; set; }

        public virtual ICollection<OrderDetailDTO> OrderDetails { get; set; } = new List<OrderDetailDTO>();
    }

    public class CreateOrderDTO
    {
        public int MemberId { get; set; }
        public int? VoucherId { get; set; }
        public int StatusId { get; set; }
    }

    public class UpdateOrderDTO
    {
        public int? VoucherId { get; set; }
        public int StatusId { get; set; }

    }
}
