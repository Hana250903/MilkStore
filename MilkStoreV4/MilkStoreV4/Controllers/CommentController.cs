using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories.UnitOfWork;

namespace MilkStoreV4.Controllers
{
    [Route("api/comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CommentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var comments = _unitOfWork.CommentRepository.Get();

            return Ok(comments);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById([FromRoute]int id)
        {
            var comment = _unitOfWork.CommentRepository.GetByID(id);
            return Ok(comment);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute]int id)
        {
            var comment = _unitOfWork.MilkRepository.GetByID(id);
            _unitOfWork.CommentRepository.Delete(comment);
            return NoContent();
        }
    }
}
