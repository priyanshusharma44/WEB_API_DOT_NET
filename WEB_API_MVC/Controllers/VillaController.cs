using Microsoft.AspNetCore.Mvc;
using WEB_API_MVC.Models;
using WEB_API_MVC.Models.DTO;
using WEB_API_MVC.Services.IServices;

namespace WEB_API_MVC.Controllers
{
    public class VillaController : Controller
    {
        private readonly IVillaService _villaService;
        public VillaController(IVillaService villaService)
        {
            _villaService = villaService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> IndexVilla()
        {
            var response = await _villaService.GetAllAsync<APIResponse>();
            if(response! == null)
            {
                var villas = response.Result;
                return View(villas);
            }
            return View(new List<VillaDTO>());

        }
    }
}
