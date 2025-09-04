using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEB_API_DOT_NET.Data;
using WEB_API_DOT_NET.Models;
using WEB_API_DOT_NET.Models.DTO;

namespace WEB_API_DOT_NET.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/VillaAPI")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        private ILogger<VillaAPIController> _logger;
     
        private ApplicationDbContext _db;
        
        private IMapper _mapper;

        public VillaAPIController(ILogger<VillaAPIController> logger, ApplicationDbContext db, IMapper mapper)
        {
            _logger = logger;
            _db = db;
            _mapper = mapper;
           
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VillaDTO>>> GetVillas()
        {
            _logger.LogInformation("Getting all villas");
            var villa =await _db.Villas.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<VillaDTO>>(villa));
         
        }
        //only one villa why no IEnumerable? cause its for list but
        //we want only 1 data details so no enum

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        /*        [ProducesResponseType(200,Type = typeof(VillaDTO))]
                [ProducesResponseType(404, Type = typeof(VillaDTO))] //notfound
                [ProducesResponseType(400, Type = typeof(VillaDTO))] //bad req*/
        public async Task<ActionResult<VillaDTO>> GetVillas(int id)

        {
            if (id == 0)
            {
                _logger.LogError("Get villa error " + id);
                return BadRequest();
            }

            var villa = await _db.Villas.FirstOrDefaultAsync(u => u.Id == id);
            if (villa == null)
            {
                return NotFound();
            }
            var villaDTO = _mapper.Map<VillaDTO>(villa);
            return Ok(villaDTO);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<VillaDTO>> CreateVilla([FromBody] VillaCreateDTO villaDTO)
        {
            if (villaDTO == null)
            {
                return BadRequest(villaDTO);
            }
            if( await _db.Villas.FirstOrDefaultAsync(u=>u.Name.ToLower()==villaDTO.Name.ToLower())!=null)
            {
                ModelState.AddModelError("CustomeError", "Villa already exists!");
                return BadRequest(ModelState);
            }
            var villa = _mapper.Map<Villa>(villaDTO);
            await _db.Villas.AddAsync(villa);
            await _db.SaveChangesAsync();
            return Ok(villaDTO);
        }
        [HttpDelete("id")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            if(id== 0)
            {
                return BadRequest();
            }
            var villa =await _db.Villas.FirstOrDefaultAsync(u=> u.Id==id);

            if (villa == null)
            {
                return NotFound();
            }
          
           _db.Villas.Remove(villa);
           await _db.SaveChangesAsync();
           return NoContent();
        }
        [HttpPut("id")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(int id, [FromBody] VillaUpdateDTO villaDTO)
        {
            if (id != villaDTO.Id)
            {
                return BadRequest();
            }
           var villas = _mapper.Map<Villa>(villaDTO);

            _db.Villas.Update(villas);
           await _db.SaveChangesAsync();
            return NoContent();

        }
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdatePartialVilla(int id, JsonPatchDocument<VillaUpdateDTO> patchDTO)
        {
            if(patchDTO==null || id==0)
            {
                return BadRequest();
            }
            var villa =await _db.Villas.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
            if (villa == null)
            {
                return NotFound();
            }
            var villaDTO = _mapper.Map<VillaUpdateDTO>(villa);
           
            patchDTO.ApplyTo(villaDTO,ModelState);

            // Map back from DTO to tracked entity
            var villass = _mapper.Map(villaDTO,villa);

           await _db.SaveChangesAsync();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return NoContent();

        }
        
    }
} 