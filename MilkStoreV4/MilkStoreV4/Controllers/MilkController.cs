using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkStoreV4.DTOs;
using MilkStoreV4.Mappers;
using Repositories.UnitOfWork;

namespace MilkStoreV4.Controllers
{
    [Route("api/milks")]
    [ApiController]
    public class MilkController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MilkController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var milks = _unitOfWork.MilkRepository.Get();
            var milkDTOs = _mapper.Map<IEnumerable<MilkDTO>>(milks);
            return Ok(milkDTOs);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById([FromRoute]int id)
        {
            var milk = MilkMapper.ToMilkDTO(_unitOfWork.MilkRepository.GetByID(id));
            if (milk == null)
            {
                return NotFound();
            }
            return Ok(milk);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute]int id)
        {
            var milk = _unitOfWork.MilkRepository.GetByID(id);
            _unitOfWork.MilkRepository.Delete(milk);
            _unitOfWork.Save();
            return NoContent();
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateMilkDTO createMilkDTO)
        {
            var milk = MilkMapper.ToMilkFromCreateDTO(createMilkDTO);
            _unitOfWork.MilkRepository.Insert(milk);
            _unitOfWork.Save();
            return CreatedAtAction(nameof(GetById), new {id = milk.MilkId}, milk);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateMilkDTO updateMilkDTO)
        {
            var milk = _unitOfWork.MilkRepository.GetByID(id);
            if (milk == null) { return NotFound(); }

            MilkMapper.ToMilkFromUpdateDTO(updateMilkDTO, milk);
            _unitOfWork.MilkRepository.Update(milk);
            _unitOfWork.Save();
            return NoContent();
        }
    }
}
