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
        public CustomerController(IUnitOfWork unitOfWork, IMapper mapper)
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
                List<Customer> customers = await _unitOfWork.customerRepository.GetAll(tracked: false);
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
        [HttpGet("{customerId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> GetCustomerById(int? customerId)
        {
            try
            {
                if (customerId == 0 || customerId == null)
                {
                    return BadRequest();
                }
                Customer customer = await _unitOfWork.customerRepository.Get(filter: x => x.CustomerId == customerId, tracked: false);
                if (customer == null)
                {
                    return NotFound();
                }
                CustomerDTO customerDTO = _mapper.Map<CustomerDTO>(customer);
                _apiResponse.IsSuccess = true;
                _apiResponse.StatusCode = HttpStatusCode.OK;
                _apiResponse.Result = customerDTO;
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
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> CreateCustomer([FromBody] CustomerCreateDTO customerCreateDTO)
        {
            try
            {
                if (customerCreateDTO == null)
                {
                    return BadRequest();
                }
                var customerFromDb = await _unitOfWork.customerRepository.Get(filter: x => x.Email.ToLower() == customerCreateDTO.Email.ToLower(), tracked: false);
                if (customerFromDb != null)
                {
                    return BadRequest("this customer already exists");
                }
                Customer customerToDb = _mapper.Map<Customer>(customerCreateDTO);
                await _unitOfWork.customerRepository.Create(customerToDb);
                await _unitOfWork.Save();

                _apiResponse.IsSuccess = true;
                _apiResponse.StatusCode = HttpStatusCode.OK;
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

        [HttpPut("update/{customerId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdateCustomer(int? customerId, [FromBody] CustomerUpdateDTO customerUpdateDTO)
        {
            try 
            {
                if (customerId == 0 || customerId == null)
                {
                    return BadRequest();
                }
                if (customerUpdateDTO == null)
                {
                    return BadRequest();
                }
                Customer customerFromDb = await _unitOfWork.customerRepository.Get(filter: x => x.CustomerId == customerUpdateDTO.CustomerId);
                if (customerFromDb == null)
                {
                    return BadRequest();
                }
                customerUpdateDTO.CustomerId = (int)customerId;

                Customer customerToDb = _mapper.Map<Customer>(customerUpdateDTO);
                _unitOfWork.customerRepository.Update(customerToDb);
                await _unitOfWork.Save();
                _apiResponse.IsSuccess = true;
                _apiResponse.StatusCode = HttpStatusCode.OK;
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
