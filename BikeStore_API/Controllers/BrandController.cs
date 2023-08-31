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
    public class BrandController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly APIResponse _ApiResposne;
        public BrandController(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _ApiResposne = new APIResponse();
        }

        [HttpGet("Brands")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> GetAllBrands()
        {
            try 
            {
                List<Brand>? brands = await _unitOfWork.brandRepository.GetAll(tracked:false);
                if (brands == null)
                {
                    return NotFound("No brands founds");
                }

                List<BrandDTO> brandsDTOs = _mapper.Map<List<BrandDTO>>(brands);

                _ApiResposne.IsSuccess = true;
                _ApiResposne.StatusCode = HttpStatusCode.OK;
                _ApiResposne.Result = brandsDTOs;
                return _ApiResposne;
            }catch(Exception ex) 
            {
                _ApiResposne.IsSuccess = false;
                _ApiResposne.StatusCode = HttpStatusCode.BadRequest;
                _ApiResposne.ErrorMessages = new List<string>() { ex.ToString()};
                return _ApiResposne;
            }
        }
        [HttpGet("{brandId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> GetBrandById(int? brandId)
        {
            try 
            {
                if (brandId == 0 || brandId == null) 
                {
                    return BadRequest();
                }
                Brand? brand = await _unitOfWork.brandRepository.Get(filter:x=>x.BrandId == brandId, tracked: false);
                if (brand == null) 
                {
                    return NotFound("no brandUpdateDTO exists with this id");
                }
                BrandDTO brandDTO = _mapper.Map<BrandDTO>(brand);
                _ApiResposne.IsSuccess = true;
                _ApiResposne.StatusCode = HttpStatusCode.OK;
                _ApiResposne.Result = brandDTO;
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

        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> CreateBrand([FromBody] BrandCreateDTO brandCreateDTO)
        {
            try 
            {
                if (brandCreateDTO == null)
                {
                    return BadRequest();
                }
               Brand? isBrandExistsInDb = await _unitOfWork.brandRepository.Get(filter: x => x.BrandName.ToLower() == brandCreateDTO.BrandName.ToLower(), tracked: false);
                if (isBrandExistsInDb != null)
                {
                    return BadRequest("this brand already exists");
                }
                Brand brandToDb = _mapper.Map<Brand>(brandCreateDTO);
                await _unitOfWork.brandRepository.Create(brandToDb);
                await _unitOfWork.Save();

                _ApiResposne.IsSuccess = true;
                _ApiResposne.StatusCode = HttpStatusCode.Created;
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

        [HttpPut("Update{brandId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdateBrand(int? brandId, [FromBody] BrandUpdateDTO brandUpdateDTO)
        {
            try 
            {
                if (brandId == 0 || brandId == null)
                {
                    return BadRequest();
                }
                if (brandUpdateDTO == null)
                {
                    return BadRequest();
                }
                 
                Brand? brandIsExists = await _unitOfWork.brandRepository.Get(filter: x => x.BrandId == brandId, tracked: false);
                if (brandIsExists == null)
                {
                    return NotFound("no brand exists with this id");
                }

                brandUpdateDTO.BrandId = (int) brandId;

                Brand brandToDb = _mapper.Map<Brand>(brandUpdateDTO);

                _unitOfWork.brandRepository.Update(brandToDb);
                await _unitOfWork.Save();

                _ApiResposne.IsSuccess = true;
                _ApiResposne.StatusCode = HttpStatusCode.OK;
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
        [HttpDelete("{brandId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<APIResponse>> DeleteBrand(int? brandId) 
        {
            try 
            {
                if (brandId == 0 || brandId == null)
                {
                    return BadRequest();
                }
                Brand? brand = await _unitOfWork.brandRepository.Get(filter: x => x.BrandId == brandId);
                if (brand == null) 
                {
                    return NotFound();
                }
                _unitOfWork.brandRepository.Delete(brand);
                await _unitOfWork.Save();

                _ApiResposne.IsSuccess = true;
                _ApiResposne.StatusCode = HttpStatusCode.NoContent;
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
