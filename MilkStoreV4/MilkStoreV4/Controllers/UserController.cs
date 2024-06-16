using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkStoreV4.DTOs;
using MilkStoreV4.Mappers;
using Repositories.UnitOfWork;

namespace MilkStoreV4.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _unitOfWork.UserRepository.Get();
            var userDTOs = _mapper.Map<IEnumerable<UserDTO>>(users);
            return Ok(userDTOs);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var users = UserMapper.ToUserDTO(_unitOfWork.UserRepository.GetByID(id));
            if (users == null)
            {
                return NotFound();
            }
            return Ok(users);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var users = UserMapper.ToUserDTO(_unitOfWork.UserRepository.GetByID(id));
            if (users == null)
            {
                return NotFound();
            }
            _unitOfWork.UserRepository.Delete(users);
            _unitOfWork.Save();
            return NoContent();
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateUserDTO createUserDTO)
        {
            var user = UserMapper.ToUserFromCreateDTO(createUserDTO);
            _unitOfWork.UserRepository.Insert(user);
            _unitOfWork.Save();
            return CreatedAtAction(nameof(GetById), new { id = user.UserId }, user);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] int id ,[FromBody] UpdateUserDTO updateUserDTO)
        {
            var user = _unitOfWork.UserRepository.GetByID(id);
                if (user == null) 
                { return NotFound(); }
                
            UserMapper.ToUserFromUpdateDTO(updateUserDTO, user);
            _unitOfWork.UserRepository.Update(user);
            _unitOfWork.Save();
            return NoContent();
        }
    }
}
