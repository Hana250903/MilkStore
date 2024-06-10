using MilkStoreV4.DTOs;
using Repositories.Models;

namespace MilkStoreV4.Mappers
{
    public static class OrderMapper
    {
        public static OrderDTO ToOrderDTO(this Order order)
        {
            return new OrderDTO
            {
                OrderId = order.OrderId,
                MemberId = order.MemberId,
                VoucherId = order.VoucherId,
                DateCreate = order.DateCreate,
                Amount = order.Amount,
                OrderStatus = order.OrderStatus,
            };
        }
        public static Order ToOrderFromCreateDTO(this CreateOrderDTO order)
        {
            return new Order
            {
                MemberId = order.MemberId,
                VoucherId = order.VoucherId,
                DateCreate = order.DateCreate,
                Amount = order.Amount,
                OrderStatus = order.OrderStatus,
            };
        }
        public static void ToOrderFromUpdateDTO(this UpdateOrderDTO orderDTO, Order order)
        {
            order.VoucherId = orderDTO.VoucherId;
            order.DateCreate = orderDTO.DateCreate;
            order.Amount = orderDTO.Amount;
            order.OrderStatus = orderDTO.OrderStatus;

        }
    }
}
