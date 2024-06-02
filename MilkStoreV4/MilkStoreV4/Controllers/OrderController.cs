using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            var orders = _unitOfWork.UserRepository.GetByID(id);
            if (orders == null)
            {
                return BadRequest();
            }
            return Ok(orders);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var orders = _unitOfWork.OrderRepository.GetByID(id);
            _unitOfWork.OrderRepository.Delete(orders);
            return NoContent();
        }
    }
}
