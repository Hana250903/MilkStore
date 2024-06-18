using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkStoreV4.DTOs;
using MilkStoreV4.Mappers;
using Repositories.UnitOfWork;

namespace MilkStoreV4.Controllers
{
    [Route("api/roles")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RoleController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var roles = _unitOfWork.RoleRepository.Get();
            var roleDTOs = _mapper.Map<IEnumerable<RoleDTO>>(roles);
            return Ok(roleDTOs);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var roles = RoleMapper.ToRoleDTO(_unitOfWork.RoleRepository.GetByID(id));
            if (roles == null)
            {
                return NotFound();
            }

            return Ok(roles);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateRoleDTO createRoleDTO)
        {
            var role = RoleMapper.ToRoleFromCreateDTO(createRoleDTO);
            _unitOfWork.RoleRepository.Insert(role);
            _unitOfWork.Save();
            return CreatedAtAction(nameof(GetById), new { id = role.RoleId }, role.ToRoleDTO());
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateRoleDTO updateRoleDTO)
        {
            var role = _unitOfWork.RoleRepository.GetByID(id);
            if (role == null)
            { return NotFound(); }

            RoleMapper.ToRoleFromUpdateDTO(updateRoleDTO, role);
            _unitOfWork.RoleRepository.Update(role);
            _unitOfWork.Save();
            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id, [FromBody] UpdateRoleDTO updateRoleDTO)
        {
            var roles = _unitOfWork.RoleRepository.GetByID(id);
            if (roles == null)
            { 
                return NotFound(); 
            }

            _unitOfWork.AdminRepository.Delete(id);
            _unitOfWork.Save();
            return NoContent();
        }
    }
}
