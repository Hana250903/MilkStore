using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkStoreV4.DTOs;
using MilkStoreV4.Mappers;
using Repositories.Models;
using Repositories.UnitOfWork;
using System.Linq.Expressions;

namespace MilkStoreV4.Controllers
{
    [Route("api/order-details")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrderDetailController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll(int? orderId = null)
        {
            Expression<Func<Orderdetail, bool>> filterExpression = null;
            if (orderId.HasValue)
            {
                filterExpression = m => m.OrderId == orderId;
            }

            var orderDetails = _unitOfWork.OrderDetailRepository.Get(filter: filterExpression);
            var orderDetailDTOs = _mapper.Map<IEnumerable<OrderDetailDTO>>(orderDetails);
            return Ok(orderDetailDTOs);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var orderDetail = OrderDetailMapper.ToOrderDetailDTO(_unitOfWork.OrderDetailRepository.GetByID(id));
            if (orderDetail == null)
            {
                return NotFound();
            }
            return Ok(orderDetail);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var orderDetail = _unitOfWork.OrderDetailRepository.GetByID(id);
            if (orderDetail == null)
            {
                return NotFound();
            }
            _unitOfWork.OrderDetailRepository.Delete(orderDetail);
            _unitOfWork.Save();
            UpdateOrderAmount(orderDetail.OrderId);
            return NoContent();
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateOrderDetailDTO orderDetailDTO)
        {
            var milk = _unitOfWork.MilkRepository.GetByID(orderDetailDTO.MilkId);
            var orderDetail = OrderDetailMapper.ToOrderDetailFromCreate(orderDetailDTO, milk.Price);
            _unitOfWork.OrderDetailRepository.Insert(orderDetail);
            _unitOfWork.Save();
            UpdateOrderAmount(orderDetail.OrderId);
            return CreatedAtAction(nameof(GetById), new { id = orderDetail.OrderDetailId }, orderDetail.ToOrderDetailDTO());
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateOrderDetailDTO orderDetailDTO)
        {
            var orderDetail = _unitOfWork.OrderDetailRepository.GetByID(id);
            var milk = _unitOfWork.MilkRepository.GetByID(orderDetail.MilkId);
            if (orderDetail == null) { return NotFound(); }

            OrderDetailMapper.ToOrderDetailFromUpdate(orderDetailDTO, orderDetail, milk.Price);
            _unitOfWork.OrderDetailRepository.Update(orderDetail);
            _unitOfWork.Save();
            UpdateOrderAmount(orderDetail.OrderId);
            return NoContent();
        }

        private void UpdateOrderAmount(int? orderId)
        {
            var orderDetails = _unitOfWork.OrderDetailRepository.Get(filter: od => od.OrderId == orderId);
            var totalAmount = orderDetails.Sum(od => od.Total);

            var order = _unitOfWork.OrderRepository.GetByID((int)orderId);
            if (order != null)
            {
                if (order.VoucherId.HasValue)
                {
                    var voucher = _unitOfWork.VoucherRepository.GetByID(order.VoucherId.Value);
                    if (voucher != null)
                    {
                        totalAmount *= (1 - voucher.Discount);
                    }
                    order.Amount = Math.Round(totalAmount, 2);
                }
                else
                {
                    order.Amount = Math.Round(totalAmount, 2);
                }
                _unitOfWork.OrderRepository.Update(order);
                _unitOfWork.Save();
            }
        }
    }
}
