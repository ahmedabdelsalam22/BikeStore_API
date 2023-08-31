using AutoMapper;
using BikeStore_API.DTOS;
using BikeStore_API.Models;
using BikeStore_API.Repository.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> GetAllCategories()
        {
            try 
            {
                List<Category> categories = await _unitOfWork.categoryRepository.GetAll();
                if (categories == null)
                {
                    return NotFound();
                }
                List<CategoryDTO> categoriesDTO = _mapper.Map<List<CategoryDTO>>(categories);

                _apiResponse.IsSuccess = true;
                _apiResponse.StatusCode = HttpStatusCode.OK;
                _apiResponse.Result = categoriesDTO;
                return _apiResponse;
            }
            catch (Exception ex) 
            {
                _apiResponse.IsSuccess = false;
                _apiResponse.ErrorMessages = new List<string>() {ex.ToString()};
                _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                return _apiResponse;
            }
        }
        [HttpGet("category{categoryId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> GetCategoryById(int? categoryId) 
        {
            try
            {
                if (categoryId == 0 || categoryId == null)
                {
                    return NotFound();
                }
                Category category = await _unitOfWork.categoryRepository.Get(filter: x => x.CategoryId == categoryId);
                if (category == null)
                {
                    return NotFound();
                }
                CategoryDTO categoryDTO = _mapper.Map<CategoryDTO>(category);
                
                _apiResponse.IsSuccess = true;
                _apiResponse.StatusCode = HttpStatusCode.OK;
                _apiResponse.Result = categoryDTO;
                return _apiResponse;
            }
            catch (Exception e) 
            {
                _apiResponse.IsSuccess = false;
                _apiResponse.ErrorMessages = new List<string>() { e.ToString() };
                _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                return _apiResponse;
            }
        }
        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<APIResponse>> CreateCategory([FromBody] CategoryCreateDTO categoryCreateDTO)
        {
            if (categoryCreateDTO == null) 
            {
                return BadRequest();
            }
            var categoryFromDb = await _unitOfWork.categoryRepository.Get(filter:x=>x.CategoryName.ToLower() == categoryCreateDTO.CategoryName.ToLower());
            if (categoryFromDb != null)
            {
                return BadRequest("category already exists");
            }
            Category category = _mapper.Map<Category>(categoryCreateDTO);
            await _unitOfWork.categoryRepository.Create(category);
            return Ok();
        }
    }
}
