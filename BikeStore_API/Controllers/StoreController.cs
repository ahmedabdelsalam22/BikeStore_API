﻿using AutoMapper;
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
            if (storeId == null || storeId == 0) 
            {
                return BadRequest();
            }
            Store store = await _unitOfWork.storeRepository.Get(filter:x=>x.StoreId == storeId,tracked:false);
            if (store == null)
            {
                return NotFound();
            }
            StoreDTO storeDTO = _mapper.Map<StoreDTO>(store);
            return Ok(storeDTO);
        }
    }
}
