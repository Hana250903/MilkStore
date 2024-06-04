using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories.UnitOfWork;

namespace MilkStoreV4.Controllers
{
    [Route("api/staffs")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public StaffController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetAll() 
        {
            var staffs = _unitOfWork.StaffRepository.Get();
            return Ok(staffs);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById([FromRoute] int id) 
        {
            var staffs = _unitOfWork.StaffRepository.GetByID(id);
            if (staffs == null)
            {
                return NotFound();
            }
            return Ok(staffs);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var staffs = _unitOfWork.StaffRepository.GetByID(id);
            _unitOfWork.StaffRepository.Delete(staffs);
            return NoContent();
        }
    }
}
