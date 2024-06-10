using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkStoreV4.DTOs;
using MilkStoreV4.Mappers;
using Repositories.UnitOfWork;

namespace MilkStoreV4.Controllers
{
    [Route("api/members")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public MemberController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var members = _unitOfWork.MemberRepository.Get();
            return Ok(members);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var members = MemberMapper.ToMemberDTO(_unitOfWork.MemberRepository.GetByID(id));
            if (members == null)
            {
                return NotFound();
            }
            return Ok(members);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var members = MemberMapper.ToMemberDTO(_unitOfWork.MemberRepository.GetByID(id));
            _unitOfWork.MemberRepository.Delete(members);
            return NoContent();
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateMemberDTO createMemberDTO)
        {
            var member = MemberMapper.ToMemberFromCreateDTO(createMemberDTO);
            _unitOfWork.MemberRepository.Insert(member);
            _unitOfWork.Save();
            return CreatedAtAction(nameof(GetById), new { id = member.MemberId }, member);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] int id ,[FromBody] UpdateMemberDTO updateMemberDTO)
        {
            var member = _unitOfWork.MemberRepository.GetByID(id);
            if (member == null)
            { 
            return NotFound(); 
            }

            MemberMapper.ToMemberFromUpdateDTO(updateMemberDTO, member);
            _unitOfWork.MemberRepository.Update(member);
            _unitOfWork.Save();
            return NoContent();
        }
    }
}
