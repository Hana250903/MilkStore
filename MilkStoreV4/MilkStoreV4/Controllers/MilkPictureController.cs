using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkStoreV4.DTOs;
using MilkStoreV4.Mappers;
using Repositories.Models;
using Repositories.UnitOfWork;
using System.Linq.Expressions;

namespace MilkStoreV4.Controllers
{
    [Route("api/milk-pictures")]
    [ApiController]
    public class MilkPictureController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MilkPictureController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var milkPictures = _unitOfWork.MilkPictureRepository.Get();
            var milkPictureDTOs = _mapper.Map<IEnumerable<MilkPictureDTO>>(milkPictures);
            return Ok(milkPictureDTOs);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var milkPicture = MilkPictureMapper.ToMilkPictureDTO(_unitOfWork.MilkPictureRepository.GetByID(id));
            if (milkPicture == null)
            {
                return NotFound();
            }
            return Ok(milkPicture);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var milkPicture = _unitOfWork.MilkPictureRepository.GetByID(id);
            if (milkPicture == null)
            {
                return NotFound();
            }
            _unitOfWork.MilkPictureRepository.Delete(milkPicture);
            _unitOfWork.Save();
            return NoContent();
        }

        [HttpPost]
        [Route("{milkId}")]
        public IActionResult Create([FromRoute] int milkId, [FromBody] CreateMilkPictureDTO createMilkPictureDTO)
        {
            // Tạo biểu thức lọc để kiểm tra sự tồn tại của milk với milkId
            Expression<Func<Milk, bool>> filter = m => m.MilkId == milkId;

            // Kiểm tra xem có tồn tại milk với milkId không
            if (_unitOfWork.MilkRepository.Count(filter) > 0)
            {
                var milkPicture = MilkPictureMapper.ToMilkPictureFromCreateDTO(milkId, createMilkPictureDTO);
                _unitOfWork.MilkPictureRepository.Insert(milkPicture);
                _unitOfWork.Save();
                return CreatedAtAction(nameof(GetById), new { id = milkPicture.MilkId }, milkPicture.ToMilkPictureDTO());
            }
            else
            {
                // Trả về lỗi nếu không tìm thấy milk
                return NotFound($"No milk found with ID {milkId}");
            }
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateMilkPictureDTO updateMilkPictureDTO)
        {
            var milkPicture = _unitOfWork.MilkPictureRepository.GetByID(id);
            if (milkPicture == null) { return NotFound(); }

            MilkPictureMapper.ToMilkPictureFromUpdateDTO(updateMilkPictureDTO, milkPicture);
            _unitOfWork.MilkPictureRepository.Update(milkPicture);
            _unitOfWork.Save();
            return NoContent();
        }
    }
}
