using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkStoreV4.DTOs;
using MilkStoreV4.Mappers;
using Repositories.UnitOfWork;

namespace MilkStoreV4.Controllers
{
    [Route("api/milk-types")]
    [ApiController]
    public class MilkTypeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MilkTypeController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var milkTypes = _unitOfWork.MilkTypeRepository.Get();
            var milkTypeDTOs = _mapper.Map<IEnumerable<MilkTypeDTO>>(milkTypes);
            return Ok(milkTypeDTOs);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById([FromRoute]int id)
        {
            var milkType = MilkTypeMapper.ToMilkTypeDTO(_unitOfWork.MilkTypeRepository.GetByID(id));
            if (milkType == null)
            {
                return NotFound();
            }
            return Ok(milkType);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute]int id)
        {
            var milkType = _unitOfWork.MilkTypeRepository.GetByID(id);
            if (milkType == null)
            {
                return NotFound();
            }
            _unitOfWork.MilkTypeRepository.Delete(id);
            _unitOfWork.Save();
            return NoContent();
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateMilkTypeDTO milkTypeDTO)
        {
            var milkType = MilkTypeMapper.ToMilkTypeFromCreateDTO(milkTypeDTO);
            _unitOfWork.MilkTypeRepository.Insert(milkType);
            _unitOfWork.Save();
            return CreatedAtAction(nameof(GetById), new { id = milkType.MilkTypeId }, milkType.ToMilkTypeDTO());
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody]UpdateMilkTypeDTO milkTypeDTO)
        {
            var milkType = _unitOfWork.MilkTypeRepository.GetByID(id);
            if (milkType == null)
            {
                return NotFound();
            }
            MilkTypeMapper.ToMilkTypeFromUpdateDTO(milkTypeDTO, milkType);
            _unitOfWork.MilkTypeRepository.Update(milkType);
            _unitOfWork.Save();
            return NoContent();
        }
    }
}
