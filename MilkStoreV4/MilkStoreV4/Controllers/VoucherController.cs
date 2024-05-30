using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories.UnitOfWork;

namespace MilkStoreV4.Controllers
{
    [Route("api/voucher")]
    [ApiController]
    public class VoucherController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public VoucherController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;   
        }
        [HttpGet]
        public IActionResult GetAll(IUnitOfWork unitOfWork)
        {
            var vouchers = _unitOfWork.VoucherRepository.Get();
            return Ok(vouchers);
        }
    }
}
