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
        public async Task<ActionResult<APIResponse>> GetParts()
        {
            List<Part> parts = await _unitOfWork.partRepository.GetAll();
            if (parts == null) 
            {
                return NotFound();  
            }
            List<PartDTO> partDTOs = _mapper.Map<List<PartDTO>>(parts);
            return Ok(partDTOs);
        }
    }
}
