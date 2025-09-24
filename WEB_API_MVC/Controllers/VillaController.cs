using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WEB_API_MVC.Models.DTO;
using WEB_API_MVC.Services.IServices;
using Villa_Utility;
using WEB_API_MVC.Models;

namespace WEB_API_MVC.Controllers
{
    public class VillaController : Controller
    {
        private readonly IVillaService _villaService;

        public VillaController(IVillaService villaService)
        {
            _villaService = villaService;
        }

        [HttpGet]
        public async Task<IActionResult> IndexVilla()
        {
            List<VillaDTO> list = new();

            var response = await _villaService.GetAllAsync<APIResponse>();
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<VillaDTO>>(Convert.ToString(response.Result));
            }

            return View(list);
        }
        [HttpGet]
        public async Task<IActionResult> DetailsVilla(int id)
        {
            if (id == 0)
                return BadRequest();

            var response = await _villaService.GetAsync<APIResponse>(id);
            if (response != null && response.IsSuccess)
            {
                // Deserialize to a single VillaDTO object
                var villa = JsonConvert.DeserializeObject<VillaDTO>(Convert.ToString(response.Result));
                return View(villa); // Pass the single villa to the view
            }

            return NotFound();
        }
        [HttpGet]
      public async Task<IActionResult> CreateVilla()
        {
            return View();  
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateVilla(VillaDTO villaDTO)
        {
            if (ModelState.IsValid)
            {
                var response = await _villaService.CreateAsync<APIResponse>(villaDTO);

                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexVilla));
                }
            }
            return View(villaDTO);
        }
        [HttpGet]
        public async Task<IActionResult> DeleteVilla(int id)
        {
            if(id == 0) return BadRequest();
            var response = await _villaService.GetAsync<APIResponse>(id);
            if (response != null && response.IsSuccess)
            {
                // Deserialize to a single VillaDTO object
                var villa = JsonConvert.DeserializeObject<VillaDTO>(Convert.ToString(response.Result));
                return View(villa); // Pass the single villa to the view
            }

            return NotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteVillaConfirmed(int id)
        {
        if (id == 0)    
        return BadRequest();

        var response = await _villaService.DeleteAsync<APIResponse>(id);
        if(response != null && response.IsSuccess)
            {
                TempData["success"] = "Villa Deleted Successfully";
                return RedirectToAction(nameof(IndexVilla));
            }
            TempData["failed"] = "Villa Deleted Unsuccessful";
            return RedirectToAction(nameof(IndexVilla));

        }
            

    }
}
