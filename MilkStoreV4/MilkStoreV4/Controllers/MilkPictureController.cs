using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories.UnitOfWork;

namespace MilkStoreV4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MilkPictureController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public MilkPictureController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var milkPictures = _unitOfWork.MilkPictureRepository.Get();
            return Ok(milkPictures);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var milkPicture = _unitOfWork.MilkPictureRepository.GetByID(id);
            return Ok(milkPicture);
        }
    }
}
