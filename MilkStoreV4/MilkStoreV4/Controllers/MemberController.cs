﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkStoreV4.DTOs;
using MilkStoreV4.Mappers;
using Repositories.Models;
using Repositories.UnitOfWork;
using System.Drawing.Printing;
using System.Linq.Expressions;

namespace MilkStoreV4.Controllers
{
    [Route("api/members")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MemberController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll(int? userId = null)
        {
            Expression<Func<Member, bool>> filterExpression = null;
            if (userId != null)
            {
                filterExpression = m => m.UserId == userId;
            }
            var members = _unitOfWork.MemberRepository.Get(filter: filterExpression, includeProperties: "Orders");
            var memberDTOs = _mapper.Map<IEnumerable<MemberDTO>>(members);
            return Ok(memberDTOs);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var member = _unitOfWork.MemberRepository.GetByID(id);
            if (member == null)
            {
                return NotFound();
            }
            member.Orders = _unitOfWork.OrderRepository.Get().Where(m => m.MemberId == member.MemberId).ToList();
            var memberDTO = MemberMapper.ToMemberDTO(member);
            return Ok(memberDTO);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var members = _unitOfWork.MemberRepository.GetByID(id);
            if (members == null)
            {
                return NotFound();
            }
            _unitOfWork.MemberRepository.Delete(id);
            _unitOfWork.Save();
            return NoContent();
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateMemberDTO createMemberDTO)
        {
            var member = MemberMapper.ToMemberFromCreateDTO(createMemberDTO);
            _unitOfWork.MemberRepository.Insert(member);
            _unitOfWork.Save();
            return CreatedAtAction(nameof(GetById), new { id = member.MemberId }, member.ToMemberDTO());
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
