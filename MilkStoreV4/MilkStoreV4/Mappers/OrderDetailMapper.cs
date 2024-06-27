using MilkStoreV4.DTOs;
using Repositories.Models;

namespace MilkStoreV4.Mappers
{
    public static class OrderDetailMapper
    {
        public static OrderDetailDTO ToOrderDetailDTO(this Orderdetail orderDetailDTO)
        {
            return new OrderDetailDTO
            {
                OrderDetailId = orderDetailDTO.OrderDetailId,
                OrderId = orderDetailDTO.OrderId,
                MilkId = orderDetailDTO.MilkId,
                Quantity = orderDetailDTO.Quantity,
                Total = orderDetailDTO.Total,
            };
        }

        public static Orderdetail ToOrderDetailFromCreate(this CreateOrderDetailDTO orderDetailDTO, double milkPrice)
        {
            return new Orderdetail
            {
                OrderId = orderDetailDTO.OrderId,
                MilkId = orderDetailDTO.MilkId,
                Quantity = orderDetailDTO.Quantity,
                Total = orderDetailDTO.Quantity * milkPrice,
            };
        }

        public static void ToOrderDetailFromUpdate(this UpdateOrderDetailDTO orderDetailDTO, Orderdetail orderDetail, double milkPrice)
        {
            orderDetail.Quantity = orderDetailDTO.Quantity;
            orderDetail.Total = orderDetailDTO.Quantity * milkPrice;
        }
    }
}
