using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories.UnitOfWork;

namespace MilkStoreV4.Controllers
{
    [Route("api/milk-type")]
    [ApiController]
    public class MilkTypeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public MilkTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var milkTypes = _unitOfWork.MilkTypeRepository.Get();

            return Ok(milkTypes);
        }
    }
}
