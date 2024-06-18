using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkStoreV4.DTOs;
using MilkStoreV4.Mappers;
using Repositories.Models;
using Repositories.UnitOfWork;

namespace MilkStoreV4.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrderController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAll(bool? IsDescending = null, int? pageIndex = null, int? pageSize = null)
        {
            Func<IQueryable<Order>, IOrderedQueryable<Order>> orderBy = null;
            if (IsDescending.HasValue)
            {
                if (IsDescending.Value)
                {
                    orderBy = q => q.OrderByDescending(e => e.OrderId);
                }
                else
                {
                    orderBy = q => q.OrderBy(e => e.OrderId);
                }
            }

            var orders = _unitOfWork.OrderRepository.Get(
                orderBy: orderBy,
                includeProperties: "Orderdetails",
                pageIndex: pageIndex,
                pageSize: pageSize
            );
            var orderDTOs = _mapper.Map<IEnumerable<OrderDTO>>(orders);
            return Ok(orderDTOs);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById([FromRoute] int id) 
        {
            var orders = OrderMapper.ToOrderDTO(_unitOfWork.OrderRepository.GetByID(id));
            if (orders == null)
            {
                return NotFound();
            }
            return Ok(orders);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var orders = _unitOfWork.OrderRepository.GetByID(id);
            if (orders == null)
            {
                return NotFound();
            }
            _unitOfWork.OrderRepository.Delete(id);
            _unitOfWork.Save();
            return NoContent();
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateOrderDTO createOrderDTO)
        {
            var order = OrderMapper.ToOrderFromCreateDTO(createOrderDTO);
            _unitOfWork.OrderRepository.Insert(order);
            _unitOfWork.Save();
            return CreatedAtAction(nameof(GetById),new {id = order.OrderId}, order.ToOrderDTO());
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] int id,[FromBody] UpdateOrderDTO updateOrderDTO)
        {
            var order = _unitOfWork.OrderRepository.GetByID(id);
            if (order == null)
                { return NotFound(); }

            OrderMapper.ToOrderFromUpdateDTO(updateOrderDTO, order);
            _unitOfWork.OrderRepository.Update(order);
            _unitOfWork.Save();
            return NoContent();
        }
    }
}
