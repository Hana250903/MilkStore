using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories.UnitOfWork;

namespace MilkStoreV4.Controllers
{
    [Route("api/admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdminController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var admins = _unitOfWork.AdminRepository.Get();
            return Ok(admins);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById([FromRoute] int id)
        { 
            var admins = _unitOfWork.AdminRepository.GetByID(id);
            return Ok(admins);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete([FromRoute] int id) 
        {
            var admins = _unitOfWork.AdminRepository.GetByID(id);
            _unitOfWork.AdminRepository.Delete(admins);
            return NoContent();
        } 

    }
}
