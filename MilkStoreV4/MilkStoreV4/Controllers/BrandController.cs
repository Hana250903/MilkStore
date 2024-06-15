using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkStoreV4.DTOs;
using MilkStoreV4.Mappers;
using Repositories.UnitOfWork;

namespace MilkStoreV4.Controllers
{
    [Route("api/brands")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BrandController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var brands = _unitOfWork.BrandRepository.Get();
            var brandDTOs = _mapper.Map<IEnumerable<BrandDTO>>(brands);
            return Ok(brandDTOs);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById([FromRoute]int id)
        {
            var brand = _unitOfWork.BrandRepository.GetByID(id);
            if (brand == null)
            {
                return NotFound();
            }
            return Ok(brand);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute]int id)
        {
            var brand = _unitOfWork.BrandRepository.GetByID(id);
            _unitOfWork.BrandRepository.Delete(brand);
            _unitOfWork.Save();
            return NoContent();
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateBrandDTO brandDTO)
        {
            var brand = BrandMapper.ToBrandFromCreateDTO(brandDTO);
            _unitOfWork.BrandRepository.Insert(brand);
            _unitOfWork.Save();
            return CreatedAtAction(nameof(GetById), new { id = brand.BrandId }, brand);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateBrandDTO brandDTO)
        {
            var brand = _unitOfWork.BrandRepository.GetByID(id);
            if(brand == null)
            {
                return NotFound(); 
            }

            BrandMapper.ToBrandFromUpdateDTO(brandDTO, brand);
            _unitOfWork.BrandRepository.Update(brand);
            _unitOfWork.Save();
            return NoContent();
        }
    }
}
