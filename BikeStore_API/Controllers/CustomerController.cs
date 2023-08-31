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
    public class CustomerController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly APIResponse _apiResponse;
        private readonly IMapper _mapper;
        public CustomerController(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _apiResponse = new APIResponse();
        }
        [HttpGet("customers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetCustomers() 
        {
            try 
            {
                List<Customer> customers = await _unitOfWork.customerRepository.GetAll();
                if (customers == null)
                {
                    return NotFound();
                }
                List<CustomerDTO> customersDTO = _mapper.Map<List<CustomerDTO>>(customers);
                _apiResponse.IsSuccess = true;
                _apiResponse.StatusCode = HttpStatusCode.OK;
                _apiResponse.Result = customersDTO;
                return _apiResponse;
            }
            catch (Exception ex)
            {
                _apiResponse.IsSuccess = false;
                _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                _apiResponse.ErrorMessages = new List<string>() { ex.ToString() };
                return _apiResponse;
            }
        }
    }
}
