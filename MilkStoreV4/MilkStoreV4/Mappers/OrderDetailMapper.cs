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
                OrderDetailId = orderDetailDTO.OrderId,
                OrderId = orderDetailDTO.OrderId,
                MilkId = orderDetailDTO.MilkId,
                Quantity = orderDetailDTO.Quantity,
                Total = orderDetailDTO.Total,
            };
        }

        public static Orderdetail ToOrderDetailFromCreate(this CreateOrderDetailDTO orderDetailDTO)
        {
            return new Orderdetail
            {
                OrderId = orderDetailDTO.OrderId,
                MilkId = orderDetailDTO.MilkId,
                Quantity = orderDetailDTO.Quantity,
                Total = orderDetailDTO.Total,
            };
        }

        public static void ToOrderDetailFromUpdate(this UpdateOrderDetailDTO orderDetailDTO, Orderdetail orderDetail)
        {
            orderDetail.Quantity = orderDetailDTO.Quantity;
            orderDetail.Total = orderDetailDTO.Total;
        }
    }
}
