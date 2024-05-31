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

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById([FromRoute]int id)
        {
            var milkType = _unitOfWork.MilkTypeRepository.GetByID(id);
            return Ok(milkType);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute]int id)
        {
            var milkType = _unitOfWork.MilkTypeRepository.GetByID(id);
            _unitOfWork.MilkTypeRepository.Delete(id);
            return NoContent();
        }
    }
}
