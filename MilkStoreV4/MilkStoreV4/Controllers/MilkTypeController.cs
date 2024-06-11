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

        public MilkTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var milkTypes = _unitOfWork.MilkTypeRepository.Get();

            return Ok(milkTypes);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById([FromRoute]int id)
        {
            var milkType = _unitOfWork.MilkTypeRepository.GetByID(id);
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
            return CreatedAtAction(nameof(GetById), new { id = milkType.MilkTypeId }, milkType);
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
