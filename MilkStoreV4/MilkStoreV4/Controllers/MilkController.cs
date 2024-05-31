using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories.UnitOfWork;

namespace MilkStoreV4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MilkController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public MilkController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var milks = _unitOfWork.MilkRepository.Get();
            return Ok(milks);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById([FromRoute]int id)
        {
            var milk = _unitOfWork.MilkRepository.GetByID(id);
            return Ok(milk);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute]int id)
        {
            var milk = _unitOfWork.MilkRepository.GetByID(id);
            _unitOfWork.MilkRepository.Delete(milk);
            return NoContent();
        }
    }
}
