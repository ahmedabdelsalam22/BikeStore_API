using AutoMapper;
using BikeStore_API.DTOS;
using BikeStore_API.Models;
using BikeStore_API.Repository.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BikeStore_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly APIResponse _apiResponse;
        private readonly IMapper _mapper;
        public CategoryController(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _apiResponse = new APIResponse();
            _mapper = mapper;
        }

        [HttpGet("categories")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetAllCategories()
        {
            List<Category> categories = await _unitOfWork.categoryRepository.GetAll();
            if (categories == null) 
            {
                return NotFound();
            }
            List<CategoryDTO> categoriesDTO = _mapper.Map<List<CategoryDTO>>(categories);
            return Ok(categories);
        }

    }
}
