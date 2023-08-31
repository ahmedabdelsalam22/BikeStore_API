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
    public class StoreController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly APIResponse _apiResponse;
        public StoreController(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _apiResponse = new APIResponse();
        }

        [HttpGet("stores")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetAllStores() 
        {
            try 
            {
                List<Store> stores = await _unitOfWork.storeRepository.GetAll(tracked: false);
                if (stores == null)
                {
                    return NotFound();
                }
                List<StoreDTO> storeDTOs = _mapper.Map<List<StoreDTO>>(stores);

                _apiResponse.IsSuccess = true;
                _apiResponse.StatusCode = HttpStatusCode.OK;
                _apiResponse.Result = storeDTOs;
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
        [HttpGet("{storeId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetStoreById(int? storeId)
        {
            try 
            {
                if (storeId == null || storeId == 0)
                {
                    return BadRequest();
                }
                Store store = await _unitOfWork.storeRepository.Get(filter: x => x.StoreId == storeId, tracked: false);
                if (store == null)
                {
                    return NotFound();
                }
                StoreDTO storeDTO = _mapper.Map<StoreDTO>(store);
                _apiResponse.IsSuccess = true;
                _apiResponse.StatusCode = HttpStatusCode.OK;
                _apiResponse.Result = storeDTO;
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
        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<APIResponse>> CreateStore([FromBody]StoreCreateDTO storeCreateDTO)
        {
            try 
            {
                if (storeCreateDTO == null)
                {
                    return BadRequest();
                }
                var storeIsExistsInDb = await _unitOfWork.storeRepository.Get(filter: x => x.StoreName.ToLower() == storeCreateDTO.StoreName.ToLower());
                if (storeIsExistsInDb != null)
                {
                    return BadRequest("store already exists");
                }
                Store storeToDB = _mapper.Map<Store>(storeCreateDTO);
                await _unitOfWork.storeRepository.Create(storeToDB);
                await _unitOfWork.Save();

                _apiResponse.IsSuccess = true;
                _apiResponse.StatusCode = HttpStatusCode.Created;
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
        [HttpPut("update/{storeId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status304NotModified)]
        public async Task<ActionResult<APIResponse>> UpdateStore(int? storeId, [FromBody]StoreUpdateDTO storeUpdateDTO) 
        {
            try 
            {
                if (storeId == null || storeId == 0)
                {
                    return BadRequest();
                }
                if (storeUpdateDTO == null)
                {
                    return BadRequest();
                }
                Store storeFromDb = await _unitOfWork.storeRepository.Get(filter: x => x.StoreId == storeUpdateDTO.StoreId, tracked: false);
                if (storeFromDb == null)
                {
                    return NotFound();
                }
                storeUpdateDTO.StoreId = (int)storeId;

                Store storeToDb = _mapper.Map<Store>(storeUpdateDTO);
                _unitOfWork.storeRepository.Update(storeToDb);
                await _unitOfWork.Save();

                _apiResponse.IsSuccess = true;
                _apiResponse.StatusCode = HttpStatusCode.OK;
                return _apiResponse;
            }
            catch (Exception ex)
            {
                _apiResponse.IsSuccess = false;
                _apiResponse.ErrorMessages = new List<string>() { ex.ToString() };
                _apiResponse.StatusCode = HttpStatusCode.NotModified;
                return _apiResponse;
            }
        }
    }
}
