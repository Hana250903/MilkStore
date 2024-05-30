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
    }
}
