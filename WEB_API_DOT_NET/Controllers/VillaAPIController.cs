using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
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
        public VillaAPIController(ILogger<VillaAPIController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public ActionResult<IEnumerable<VillaDTO>> GetVillas()
        {
            _logger.LogInformation("Getting all villas");
            return Ok(_db.Villas.ToList());
        }
        //only one villa why no IEnumerable? cause its for list but
        //we want only 1 data details so no enum

        [HttpGet("id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        /*        [ProducesResponseType(200,Type = typeof(VillaDTO))]
                [ProducesResponseType(404, Type = typeof(VillaDTO))] //notfound
                [ProducesResponseType(400, Type = typeof(VillaDTO))] //bad req*/
        public ActionResult<VillaDTO> GetVillas(int id)

        {
            if (id == 0)
            {
                _logger.LogError("Get villa error " + id);
                return BadRequest();
            }

            var villa = _db.Villas.FirstOrDefault(u => u.Id == id);
            if (villa == null)
            {
                return NotFound();
            }
            return Ok(villa);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<VillaDTO> CreateVilla([FromBody] VillaDTO villaDTO)
        {
            if (villaDTO == null)
            {
                return BadRequest(villaDTO);
            }
            if(_db.Villas.FirstOrDefault(u=>u.Name.ToLower()==villaDTO.Name.ToLower())!=null)
            {
                ModelState.AddModelError("CustomeError", "Villa already exists!");
                return BadRequest(ModelState);
            }

            Villa modal = new()
            {
                Amenity = villaDTO.Amenity,
                Details = villaDTO.Details,
                Id = villaDTO.Id,
                ImageUrl = villaDTO.ImageUrl,
                Name = villaDTO.Name,
                Occupancy = villaDTO.Occupancy,
                Rate = villaDTO.Rate,
                Sqft = villaDTO.Sqft,
            };
             _db.Villas.Add(modal);
            _db.SaveChanges();
            return Ok(villaDTO);
        }
        [HttpDelete("id")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(int id)
        {
            if(id== 0)
            {
                return BadRequest();
            }
            var villa = _db.Villas.FirstOrDefault(u=> u.Id==id);

            if (villa == null)
            {
                return NotFound();
            }
            _db.Villas.Remove(villa);
            _db.SaveChanges();
            return NoContent();
        }
        [HttpPut("id")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Put(int id, [FromBody] VillaDTO villaDTO)
        {
            if (id != villaDTO.Id)
            {
                return BadRequest();
            }
            Villa modal = new()
            {
                Amenity = villaDTO.Amenity,
                Details = villaDTO.Details,
                Id = villaDTO.Id,
                ImageUrl = villaDTO.ImageUrl,
                Name = villaDTO.Name,
                Occupancy = villaDTO.Occupancy,
                Rate = villaDTO.Rate,
                Sqft = villaDTO.Sqft,
            };

            _db.Villas.Update(modal);
            _db.SaveChanges();
            return NoContent();

        }
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdatePartialVilla(int id, JsonPatchDocument<VillaDTO> patchDTO)
        {
            if(patchDTO==null || id==0)
            {
                return BadRequest();
            }
            var villa = _db.Villas.FirstOrDefault(u => u.Id == id);
            if (villa == null)
            {
                return NotFound();
            }
            VillaDTO villaDTO = new()
            {
                Amenity = villa.Amenity,
                Details = villa.Details,
                Id = villa.Id,
                ImageUrl = villa.ImageUrl,
                Name = villa.Name,
                Occupancy = villa.Occupancy,
                Rate = villa.Rate,
                Sqft = villa.Sqft,

            };
           
            patchDTO.ApplyTo(villaDTO,ModelState);

            // Map back from DTO to tracked entity
            villa.Amenity = villaDTO.Amenity;
            villa.Details = villaDTO.Details;
            villa.ImageUrl = villaDTO.ImageUrl;
            villa.Name = villaDTO.Name;
            villa.Occupancy = villaDTO.Occupancy;
            villa.Rate = villaDTO.Rate;
            villa.Sqft = villaDTO.Sqft;

            
            _db.SaveChanges();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return NoContent();

        }
        
    }
} 