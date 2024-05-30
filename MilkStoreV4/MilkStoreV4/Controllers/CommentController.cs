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
    }
}
