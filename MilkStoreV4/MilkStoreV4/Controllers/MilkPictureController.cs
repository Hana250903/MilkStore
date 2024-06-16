using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkStoreV4.DTOs;
using MilkStoreV4.Mappers;
using Repositories.UnitOfWork;

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
        public IActionResult Create([FromBody] CreateMilkPictureDTO createMilkPictureDTO)
        {
            var milkPicture = MilkPictureMapper.ToMilkPictureFromCreateDTO(createMilkPictureDTO);
            _unitOfWork.MilkPictureRepository.Insert(milkPicture);
            _unitOfWork.Save();
            return CreatedAtAction(nameof(GetById), new { id = milkPicture.MilkId }, milkPicture);
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
