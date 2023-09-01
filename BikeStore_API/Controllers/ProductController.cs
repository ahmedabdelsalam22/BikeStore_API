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
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly APIResponse _ApiResposne;
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _ApiResposne = new APIResponse();
        }
        [HttpGet("allProducts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetProducts() 
        {
            try 
            { 
                List<Product> products = await _unitOfWork.productRepository.GetAll(tracked: false,
                               includes: new string[] { "Brand", "Category" });
                if (products == null) 
                {
                    return NotFound();
                }

                    _ApiResposne.IsSuccess = true;
                    _ApiResposne.StatusCode = HttpStatusCode.OK;
                    _ApiResposne.Result = products;
                    return _ApiResposne;
            }
            catch (Exception ex)
            {
                _ApiResposne.IsSuccess = false;
                _ApiResposne.StatusCode = HttpStatusCode.BadRequest;
                _ApiResposne.ErrorMessages = new List<string>() { ex.ToString() };
                return _ApiResposne;
            }
        }
        [HttpGet("{productId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetProductById(int? productId)
        {
            try 
            {
                if (productId == 0 || productId == null)
                {
                    return NotFound();
                }
                Product product = await _unitOfWork.productRepository.Get(tracked: false,
                                   includes: new string[] { "Brand", "Category" });
                if (product == null)
                {
                    return NotFound();
                }
                _ApiResposne.IsSuccess = true;
                _ApiResposne.StatusCode = HttpStatusCode.OK;
                _ApiResposne.Result = product;
                return _ApiResposne;
            }
            catch (Exception ex)
            {
                _ApiResposne.IsSuccess = false;
                _ApiResposne.StatusCode = HttpStatusCode.BadRequest;
                _ApiResposne.ErrorMessages = new List<string>() { ex.ToString() };
                return _ApiResposne;
            }
        }
    }
}
