using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories.UnitOfWork;

namespace MilkStoreV4.Controllers
{
    [Route("api/members")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public MemberController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var members = _unitOfWork.MemberRepository.Get();
            return Ok(members);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var members = _unitOfWork.MemberRepository.GetByID(id);
            if (members == null)
            {
                return BadRequest();
            }
            return Ok(members);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete([FromRoute] int id) {
            var members = _unitOfWork.MemberRepository.GetByID(id);
            _unitOfWork.MemberRepository.Delete(members);
            return NoContent();
    }
}
