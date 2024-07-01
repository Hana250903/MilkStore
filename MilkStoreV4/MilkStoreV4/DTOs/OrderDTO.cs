namespace MilkStoreV4.DTOs
{
    public class OrderDTO
    {
        public int OrderId { get; set; }

        public int MemberId { get; set; }

        public int? VoucherId { get; set; }

        public string DateCreate { get; set; } = null!;

        public double Amount { get; set; }

        public string OrderStatus { get; set; } = null!;
        
        public virtual ICollection<OrderDetailDTO> OrderDetails { get; set; } = new List<OrderDetailDTO>();
    }

    public class CreateOrderDTO
    {
        public int MemberId { get; set; }

        public double Amount { get; set; }

        public string OrderStatus { get; set; } = null !;
    }

    public class UpdateOrderDTO
    {
        public int? VoucherId { get; set; }

        public double Amount { get; set; }

        public string OrderStatus { get; set; } =null!;

    }
}
