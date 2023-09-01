using BikeStore_API.Models;
using BikeStore_API.Repository.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BikeStore_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly APIResponse _apiResponse;
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _apiResponse = new APIResponse();
        }
        [HttpGet("allProducts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetProducts() 
        {
            List<Product> products = await _unitOfWork.productRepository.GetAll(tracked: false,
                           includes: new string[] { "Brand", "Category" });
            if (products == null) 
            {
                return NotFound();
            }
            return Ok(products);
        }
    }
}
