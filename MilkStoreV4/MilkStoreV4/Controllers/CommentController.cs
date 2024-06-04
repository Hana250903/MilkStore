using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories.Models;
using Repositories.UnitOfWork;

namespace MilkStoreV4.Controllers
{
    [Route("api/comments")]
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
            if (comment == null)
            {
                return NotFound();
            }
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

        [HttpPost]
        public IActionResult Create([FromBody] Comment comment)
        {
            _unitOfWork.CommentRepository.Insert(comment);
            _unitOfWork.Save();
            return CreatedAtAction(nameof(GetById), new {id = comment.CommentId}, comment);
        }
    }
}
