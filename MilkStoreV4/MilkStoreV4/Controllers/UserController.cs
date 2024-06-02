using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories.UnitOfWork;

namespace MilkStoreV4.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _unitOfWork.UserRepository.Get();
            return Ok(users);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var users = _unitOfWork.UserRepository.GetByID(id);
            if (users == null)
            {
                return BadRequest();
            }
            return Ok(users);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var users = _unitOfWork.UserRepository.GetByID(id);
            _unitOfWork.UserRepository.Delete(users);
            return NoContent();
        }
    }
}
