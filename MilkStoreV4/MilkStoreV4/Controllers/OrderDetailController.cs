using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkStoreV4.DTOs;
using MilkStoreV4.Mappers;
using Repositories.UnitOfWork;

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
        public IActionResult GetAll()
        {
            var orderDetails = _unitOfWork.OrderDetailRepository.Get();
            var orderDetailDTOs = _mapper.Map<IEnumerable<OrderDetailDTO>>(orderDetails);
            return Ok(orderDetailDTOs);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById([FromRoute]int id)
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
        public IActionResult Delete([FromRoute]int id)
        {
            var orderDetail = _unitOfWork.OrderDetailRepository.GetByID(id);
            _unitOfWork.OrderDetailRepository.Delete(orderDetail);
            _unitOfWork.Save();
            return NoContent();
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateOrderDetailDTO orderDetailDTO)
        {
            var orderDetail = OrderDetailMapper.ToOrderDetailFromCreate(orderDetailDTO);
            _unitOfWork.OrderDetailRepository.Insert(orderDetail);
            _unitOfWork.Save();
            return CreatedAtAction(nameof(GetById), new { id = orderDetail.OrderDetailId }, orderDetail);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateOrderDetailDTO orderDetailDTO)
        {
            var orderDetail = _unitOfWork.OrderDetailRepository.GetByID(id);
            if (orderDetail == null) { return NotFound(); }

            OrderDetailMapper.ToOrderDetailFromUpdate(orderDetailDTO, orderDetail);
            _unitOfWork.OrderDetailRepository.Update(orderDetail);
            _unitOfWork.Save();
            return NoContent();
        }
    }
}
