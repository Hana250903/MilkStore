namespace MilkStoreV4.DTOs
{
    public class OrderDetailDTO
    {
        public int OrderDetailId { get; set; }

        public int OrderId { get; set; }

        public int MilkId { get; set; }

        public int Quantity { get; set; }

        public double Total { get; set; }
    }

    public class CreateOrderDetailDTO
    {
        public int OrderId { get; set; }

        public int MilkId { get; set; }

        public int Quantity { get; set; }

        public double Total { get; set; }
    }

    public class UpdateOrderDetailDTO
    {
        public int Quantity { get; set; }

        public double Total { get; set; }
    }
}
