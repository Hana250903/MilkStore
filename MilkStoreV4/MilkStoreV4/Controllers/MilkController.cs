using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkStoreV4.DTOs;
using MilkStoreV4.Mappers;
using Repositories.Models;
using Repositories.UnitOfWork;
using System.Linq.Expressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MilkStoreV4.Controllers
{
    [Route("api/milks")]
    [ApiController]
    public class MilkController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MilkController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll(string filter = "", bool? IsDescending = null, int? pageIndex = null, int? pageSize = null)
        {
            Expression<Func<Milk, bool>> filterExpression = null;
            if (!string.IsNullOrEmpty(filter))
            {
                filterExpression = m => m.MilkName.Contains(filter);
            }

            Func<IQueryable<Milk>, IOrderedQueryable<Milk>> orderBy = null;
            if (IsDescending.HasValue)
            {
                if (IsDescending.Value)
                {
                    orderBy = q => q.OrderByDescending(e => e.Price);
                }
                else
                {
                    orderBy = q => q.OrderBy(e => e.Price);
                }
            }

            var milks = _unitOfWork.MilkRepository.Get(
                filter: filterExpression,
                orderBy: orderBy,
                includeProperties: "Milkpictures",
                pageIndex: pageIndex,
                pageSize: pageSize
            );

            var milkDTOs = milks.Select(m => m.ToMilkDTO()).ToList();

            return Ok(milkDTOs);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById([FromRoute]int id)
        {
            var milk = MilkMapper.ToMilkDTO(_unitOfWork.MilkRepository.GetByID(id));
            if (milk == null)
            {
                return NotFound();
            }
            return Ok(milk);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute]int id)
        {
            var milk = _unitOfWork.MilkRepository.GetByID(id);
            if(milk == null)
            {
                return NotFound();
            }
            _unitOfWork.MilkRepository.Delete(milk);
            _unitOfWork.Save();
            return NoContent();
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateMilkDTO createMilkDTO)
        {
            var milk = MilkMapper.ToMilkFromCreateDTO(createMilkDTO);
            _unitOfWork.MilkRepository.Insert(milk);
            _unitOfWork.Save();
            return CreatedAtAction(nameof(GetById), new {id = milk.MilkId}, milk);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateMilkDTO updateMilkDTO)
        {
            var milk = _unitOfWork.MilkRepository.GetByID(id);
            if (milk == null) { return NotFound(); }

            MilkMapper.ToMilkFromUpdateDTO(updateMilkDTO, milk);
            _unitOfWork.MilkRepository.Update(milk);
            _unitOfWork.Save();
            return NoContent();
        }
    }
}
