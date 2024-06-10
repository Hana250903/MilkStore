using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkStoreV4.DTOs;
using MilkStoreV4.Mappers;
using Repositories.UnitOfWork;

namespace MilkStoreV4.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var orders = _unitOfWork.OrderRepository.Get();
            return Ok(orders);
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
            var orders = OrderMapper.ToOrderDTO(_unitOfWork.OrderRepository.GetByID(id));
            _unitOfWork.OrderRepository.Delete(orders);
            return NoContent();
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateOrderDTO createOrderDTO)
        {
            var order = OrderMapper.ToOrderFromCreateDTO(createOrderDTO);
            _unitOfWork.OrderRepository.Insert(order);
            _unitOfWork.Save();
            return CreatedAtAction(nameof(GetById),new {id = order.OrderId}, order);
        }

        [HttpPut]
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
