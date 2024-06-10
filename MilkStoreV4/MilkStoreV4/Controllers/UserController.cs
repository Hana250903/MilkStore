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

        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _unitOfWork.UserRepository.Get();
            return Ok(users);
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
        [Route("{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var users = UserMapper.ToUserDTO(_unitOfWork.UserRepository.GetByID(id));
            _unitOfWork.UserRepository.Delete(users);
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
