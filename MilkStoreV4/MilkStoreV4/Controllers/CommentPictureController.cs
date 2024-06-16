using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkStoreV4.DTOs;
using MilkStoreV4.Mappers;
using Repositories.UnitOfWork;

namespace MilkStoreV4.Controllers
{
    [Route("api/comment-pictures")]
    [ApiController]
    public class CommentPictureController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CommentPictureController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var commentPictures = _unitOfWork.CommentPictureRepository.Get();
            var commentPictureDTOs = _mapper.Map<IEnumerable<CommentPictureDTO>>(commentPictures);
            return Ok(commentPictureDTOs);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            var commentPicture = CommentPictureMapper.ToCommentPictureDTO(_unitOfWork.CommentPictureRepository.GetByID(id));
            if (commentPicture == null)
            {
                return NotFound();
            }
            return Ok(commentPicture);
        }

        [HttpPost]
        public IActionResult Create([FromBody]CreateCommentPictureDTO commentPictureDTO)
        {
            var commentPicture = CommentPictureMapper.ToCommentPictureFromCreateDTO(commentPictureDTO);
            _unitOfWork.CommentPictureRepository.Insert(commentPicture);
            _unitOfWork.Save();
            return CreatedAtAction(nameof(GetById), new { id = commentPicture.CommentPictureId }, commentPicture);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateCommentPictureDTO commentPictureDTO)
        {
            var commentPicture = _unitOfWork.CommentPictureRepository.GetByID(id);
            if (commentPicture == null)
            {
                return NotFound();
            }
            CommentPictureMapper.ToCommentPictureFromUpdateDTO(commentPictureDTO, commentPicture);
            _unitOfWork.CommentPictureRepository.Update(commentPicture);
            _unitOfWork.Save();
            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var commentPicture = CommentPictureMapper.ToCommentPictureDTO(_unitOfWork.CommentPictureRepository.GetByID(id));
            if(commentPicture == null)
            {
                return NotFound();
            }
            _unitOfWork.CommentPictureRepository.Delete(commentPicture);
            _unitOfWork.Save();
            return NoContent();
        }
    }
}
