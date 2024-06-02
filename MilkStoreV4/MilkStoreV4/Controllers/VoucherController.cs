using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories.UnitOfWork;

namespace MilkStoreV4.Controllers
{
    [Route("api/vouchers")]
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

        [HttpGet("{id:int}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var vouchers = _unitOfWork.VoucherRepository.GetByID(id);
            if (vouchers == null)
            {
                return BadRequest();
            }
            return Ok(vouchers);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var vouchers = _unitOfWork.VoucherRepository.GetByID(id);
            _unitOfWork.VoucherRepository.Delete(vouchers);

            return NoContent();
        }
    }
}
