using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkStoreV4.DTOs;
using MilkStoreV4.Mappers;
using Repositories.UnitOfWork;

namespace MilkStoreV4.Controllers
{
    [Route("api/staffs")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public StaffController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetAll() 
        {
            var staffs = _unitOfWork.StaffRepository.Get();
            return Ok(staffs);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById([FromRoute] int id) 
        {
            var staffs = StaffMapper.ToStaffDTO(_unitOfWork.StaffRepository.GetByID(id));
            if (staffs == null)
            {
                return NotFound();
            }
            return Ok(staffs);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var staffs = StaffMapper.ToStaffDTO(_unitOfWork.StaffRepository.GetByID(id));
            _unitOfWork.StaffRepository.Delete(staffs);
            return NoContent();
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateStaffDTO createStaffDTO)
        {
            var staff = StaffMapper.ToStaffFromCreateDTO(createStaffDTO);
            _unitOfWork.StaffRepository.Insert(staff);
            _unitOfWork.Save();
            return CreatedAtAction(nameof(GetById), new {id = staff.StaffId}, staff);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] int id , [FromBody] UpdateStaffDTO updateStaffDTO)
        {
            var staff = _unitOfWork.StaffRepository.GetByID(id); 
                if (staff == null)
            {  return NotFound(); }    
                
            StaffMapper.ToStaffFromUpdateDTO(updateStaffDTO, staff);
            _unitOfWork.StaffRepository.Update(staff);
            _unitOfWork.Save();
            return NoContent();
        }
    }
}
