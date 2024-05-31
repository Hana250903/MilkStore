using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories.UnitOfWork;

namespace MilkStoreV4.Controllers
{
    [Route("api/order-detail")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderDetailController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var orderDetails = _unitOfWork.OrderDetailRepository.Get();
            return Ok(orderDetails);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById([FromRoute]int id)
        {
            var orderDetail = _unitOfWork.OrderDetailRepository.GetByID(id);
            return Ok(orderDetail);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute]int id)
        {
            var orderDetail = _unitOfWork.OrderDetailRepository.GetByID(id);
            _unitOfWork.OrderDetailRepository.Delete(orderDetail);
            return NoContent();
        }
    }
}
