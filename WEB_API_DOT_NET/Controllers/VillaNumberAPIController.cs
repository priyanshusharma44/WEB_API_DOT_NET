using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using WEB_API_DOT_NET.Data;
using WEB_API_DOT_NET.Migrations;
using WEB_API_DOT_NET.Models;
using WEB_API_DOT_NET.Models.DTO;
using WEB_API_DOT_NET.Repository.IRepository;

namespace WEB_API_DOT_NET.Controllers
{
    [Route("api/VillaNumberAPI")]
    [ApiController]
    public class VillaNumberAPIController : ControllerBase
    {
        private readonly IVillaNumberRepository _dbVilla;
        private readonly ILogger<VillaNumberAPIController> _logger;
        private readonly IMapper _mapper;

        protected APIResponse _response;

        public VillaNumberAPIController(ILogger<VillaNumberAPIController> logger, IMapper mapper, IVillaNumberRepository dbVilla)
        {
            _logger = logger;
            _mapper = mapper;
            _dbVilla = dbVilla;
            this._response = new();
        }

        // GET ALL
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<APIResponse>> GetVillas()
        {
            try
            {
                _logger.LogInformation("Getting all villaNumbers");
                var villaList = await _dbVilla.GetAllAsync();
                _response.Result = _mapper.Map<IEnumerable<VillaNumberDTO>>(villaList);
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorsMessage = new List<string> { ex.Message };
                _response.StatusCode = HttpStatusCode.InternalServerError;
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        // GET SINGLE
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetVillas(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }

                var villa = await _dbVilla.GetAsync(u => u.VillaNo == id);
                if (villa == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    return NotFound(_response);
                }

                _response.Result = _mapper.Map<VillaNumberDTO>(villa);
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorsMessage = new List<string> { ex.Message };
                _response.StatusCode = HttpStatusCode.InternalServerError;
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        // CREATE
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> CreateVilla([FromBody] VillaNumberCreateDTO villaCreateDTO)
        {
            try
            {
                if (villaCreateDTO == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }

                if (await _dbVilla.GetAsync(u => u.VillaNo == villaCreateDTO.VillaNo) != null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorsMessage = new List<string> { "VillaNo already exists!" };
                    return BadRequest(_response);
                }

                var villa = _mapper.Map<VillaNumber>(villaCreateDTO);
                await _dbVilla.CreateAsync(villa);
                await _dbVilla.SaveAsync();

                _response.Result = _mapper.Map<VillaNumberCreateDTO>(villa);
                _response.StatusCode = HttpStatusCode.Created;
                _response.IsSuccess = true;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorsMessage = new List<string> { ex.Message };
                _response.StatusCode = HttpStatusCode.InternalServerError;
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        // DELETE
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> Delete(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }

                var villa = await _dbVilla.GetAsync(u => u.VillaNo == id);
                if (villa == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    return NotFound(_response);
                }

                await _dbVilla.RemoveAsync(villa);
                await _dbVilla.SaveAsync();

                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorsMessage = new List<string> { ex.Message };
                _response.StatusCode = HttpStatusCode.InternalServerError;
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        // UPDATE (PUT)
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> Put(int id, [FromBody] VillaNumberUpdateDTO villaUpdateDTO)
        {
            try
            {
                if (id != villaUpdateDTO.VillaNo)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }

                var villa = _mapper.Map<VillaNumber>(villaUpdateDTO);
                await _dbVilla.UpdateAsync(villa);
                await _dbVilla.SaveAsync();

                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorsMessage = new List<string> { ex.Message };
                _response.StatusCode = HttpStatusCode.InternalServerError;
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        // PARTIAL UPDATE (PATCH)
        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> UpdatePartialVilla(int id, JsonPatchDocument<VillaNumberUpdateDTO> patchDTO)
        {
            try
            {
                if (patchDTO == null || id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }

                var villa = await _dbVilla.GetAsync(u => u.VillaNo == id, tracked: false);
                if (villa == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    return NotFound(_response);
                }

                var villaDTO = _mapper.Map<VillaNumberUpdateDTO>(villa);
                patchDTO.ApplyTo(villaDTO, ModelState);

                var updatedVilla = _mapper.Map(villaDTO, villa);
                await _dbVilla.UpdateAsync(updatedVilla);
                await _dbVilla.SaveAsync();

                if (!ModelState.IsValid)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorsMessage = new List<string> { "Invalid patch data" };
                    return BadRequest(_response);
                }

                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorsMessage = new List<string> { ex.Message };
                _response.StatusCode = HttpStatusCode.InternalServerError;
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }
    }
}
