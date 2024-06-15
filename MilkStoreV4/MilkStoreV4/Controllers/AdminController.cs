using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkStoreV4.DTOs;
using MilkStoreV4.Mappers;
using Repositories.UnitOfWork;

namespace MilkStoreV4.Controllers
{
    [Route("api/admins")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AdminController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var admins = _unitOfWork.AdminRepository.Get();
            var adminDTOs = _mapper.Map<AdminDTO>(admins);
            return Ok(admins);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById([FromRoute] int id)
        { 
            var admins = AdminMapper.ToAdminDTO(_unitOfWork.AdminRepository.GetByID(id));
            if (admins == null)
            {
                return NotFound();
            }
            return Ok(admins);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete([FromRoute] int id) 
        {
            var admins = AdminMapper.ToAdminDTO(_unitOfWork.AdminRepository.GetByID(id));
            _unitOfWork.AdminRepository.Delete(admins);
            return NoContent();
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateAdminDTO createAdminDTO)
        {
            var admin = AdminMapper.ToAdminFromCreateDTO(createAdminDTO);
            _unitOfWork.AdminRepository.Insert(admin);
            _unitOfWork.Save();
            return CreatedAtAction(nameof(GetById), new {id = admin.AdminId}, admin);
        }


        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] int id,[FromBody] UpdateAdminDTO updateAdminDTO)
        {
            var admin = _unitOfWork.AdminRepository.GetByID(id);
            if (admin == null)
            { 
                return NotFound();  
            }

            AdminMapper.ToAdminFromUpdateDTO(updateAdminDTO, admin);
            _unitOfWork.AdminRepository.Update(admin);
            _unitOfWork.Save();
            return NoContent();
        }
    }
}
