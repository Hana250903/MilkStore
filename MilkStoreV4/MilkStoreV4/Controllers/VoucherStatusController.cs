using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkStoreV4.DTOs;
using MilkStoreV4.Mappers;
using Repositories.UnitOfWork;

namespace MilkStoreV4.Controllers
{
    [Route("api/voucher-status")]
    [ApiController]
    public class VoucherStatusController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public VoucherStatusController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var status = _unitOfWork.VoucherStatusRepository.Get();
            var statusDTO = status.Select(c => c.ToVoucherStatusDTO()).ToList();
            return Ok(statusDTO);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var status = VoucherStatusMapper.ToVoucherStatusDTO(_unitOfWork.VoucherStatusRepository.GetByID(id));
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
            var status = _unitOfWork.VoucherStatusRepository.GetByID(id);
            if (status == null)
            {
                return NotFound();
            }
            _unitOfWork.VoucherStatusRepository.Delete(id);
            _unitOfWork.Save();
            return NoContent();
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateVoucherStatusDTO createVoucherStatusDTO)
        {
            var status = VoucherStatusMapper.ToVoucherStatusFromCreateDTO(createVoucherStatusDTO);
            _unitOfWork.VoucherStatusRepository.Insert(status);
            _unitOfWork.Save();
            return CreatedAtAction(nameof(GetById), new { id = status.VoucherStatusId }, status.ToVoucherStatusDTO());
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateVoucherStatusDTO updateVoucherStatusDTO)
        {
            var status = _unitOfWork.VoucherStatusRepository.GetByID(id);
            if (status == null)
            { return NotFound(); }

            VoucherStatusMapper.ToVoucherStatusFromUpdateDTO(updateVoucherStatusDTO, status);
            _unitOfWork.VoucherStatusRepository.Update(status);
            _unitOfWork.Save();
            return NoContent();
        }
    }
}
