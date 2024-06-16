using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkStoreV4.DTOs;
using MilkStoreV4.Mappers;
using Repositories.UnitOfWork;

namespace MilkStoreV4.Controllers
{
    [Route("api/vouchers")]
    [ApiController]
    public class VoucherController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public VoucherController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;   
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAll(IUnitOfWork unitOfWork)
        {
            var vouchers = _unitOfWork.VoucherRepository.Get();
            var voucherDTOs = _mapper.Map<IEnumerable<VoucherDTO>>(vouchers);
            return Ok(voucherDTOs);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var vouchers = VoucherMapper.ToVoucherDTO(_unitOfWork.VoucherRepository.GetByID(id));
            if (vouchers == null)
            {
                return NotFound();
            }
            return Ok(vouchers);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var vouchers = VoucherMapper.ToVoucherDTO(_unitOfWork.VoucherRepository.GetByID(id));
            if (vouchers == null)
            {
                return NotFound();
            }
            _unitOfWork.VoucherRepository.Delete(id);
            _unitOfWork.Save();
            return NoContent();
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateVoucherDTO createVoucherDTO)
        {
            var voucher = VoucherMapper.ToVoucherFromCreateDTO(createVoucherDTO);
            _unitOfWork.VoucherRepository.Insert(voucher);
            _unitOfWork.Save();
            return CreatedAtAction(nameof(GetById),new {id = voucher.VoucherId}, voucher);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] int id,[FromBody] UpdateVoucherDTO updateVoucherDTO)
        {
            var voucher = _unitOfWork.VoucherRepository.GetByID(id); 
                if(voucher == null) 
                    { return NotFound(); }
            VoucherMapper.ToVoucherFromUpdateDTO(updateVoucherDTO, voucher);
            _unitOfWork.VoucherRepository.Update(voucher);
            _unitOfWork.Save();
            return NoContent();
        }
    }
}
