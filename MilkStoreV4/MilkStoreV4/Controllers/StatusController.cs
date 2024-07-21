using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MilkStoreV4.DTOs;
using MilkStoreV4.Mappers;
using Repositories.UnitOfWork;

namespace MilkStoreV4.Controllers
{

    [Route("api/status")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StatusController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var status = _unitOfWork.StatusRepository.Get();
            var statusDTO = status.Select(c => c.ToStatusDTO()).ToList();
            return Ok(statusDTO);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var status = StatusMapper.ToStatusDTO(_unitOfWork.StatusRepository.GetByID(id));
            if (status == null)
            {
                return NotFound();
            }
            return Ok(status);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var status = _unitOfWork.StatusRepository.GetByID(id);
            if (status == null)
            {
                return NotFound();
            }
            _unitOfWork.StatusRepository.Delete(id);
            _unitOfWork.Save();
            return NoContent();
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateStatusDTO createStatusDTO)
        {
            var status = StatusMapper.ToStatusFromCreateDTO(createStatusDTO);
            _unitOfWork.StatusRepository.Insert(status);
            _unitOfWork.Save();
            return CreatedAtAction(nameof(GetById), new { id = status.StatusId }, status.ToStatusDTO());
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateStatusDTO updateStatusDTO)
        {
            var status = _unitOfWork.StatusRepository.GetByID(id);
            if (status == null)
            { return NotFound(); }

            StatusMapper.ToStatusFromUpdateDTO(updateStatusDTO, status);
            _unitOfWork.StatusRepository.Update(status);
            _unitOfWork.Save();
            return NoContent();
        }
    }
}

