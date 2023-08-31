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
    public class PartController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly APIResponse _apiResponse;
        private readonly IMapper _mapper;
        public PartController(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _apiResponse = new APIResponse();
        }
        [HttpGet("Parts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> GetParts()
        {
            try 
            {
                List<Part> parts = await _unitOfWork.partRepository.GetAll(tracked: false);
                if (parts == null)
                {
                    return NotFound();
                }
                List<PartDTO> partDTOs = _mapper.Map<List<PartDTO>>(parts);

                _apiResponse.IsSuccess = true;
                _apiResponse.StatusCode = HttpStatusCode.OK;
                _apiResponse.Result = partDTOs;
                return _apiResponse;
            }
            catch (Exception ex)
            {
                _apiResponse.IsSuccess = false;
                _apiResponse.ErrorMessages = new List<string>() { ex.ToString() };
                _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                return _apiResponse;
            }
        }
        [HttpGet("{partId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> GetPartById(int? partId)
        {
            try 
            {
                if (partId == 0 || partId == null)
                {
                    return BadRequest();
                }
                Part part = await _unitOfWork.partRepository.Get(filter: x => x.PartId == partId, tracked: false);
                if (part == null)
                {
                    return NotFound();
                }
                PartDTO partDTO = _mapper.Map<PartDTO>(part);

                _apiResponse.IsSuccess = true;
                _apiResponse.StatusCode = HttpStatusCode.OK;
                _apiResponse.Result = partDTO;
                return _apiResponse;
            }
            catch (Exception ex)
            {
                _apiResponse.IsSuccess = false;
                _apiResponse.ErrorMessages = new List<string>() { ex.ToString() };
                _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                return _apiResponse;
            }
        }
    }
}
