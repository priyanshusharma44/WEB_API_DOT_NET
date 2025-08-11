using Microsoft.AspNetCore.Mvc;
using WEB_API_DOT_NET.Models;

namespace WEB_API_DOT_NET.Controllers
{
    [Route("api/VillaAPI")]
    [ApiController]
    public class VillaAPIController: ControllerBase
    {
        [HttpGet]
        public IEnumerable<Villa> GetVillas()
        {
            return new List<Villa>
            {
                new Villa
                {
                    Id = 1,
                    Name="RAM"
                },
                new Villa
                {
                    Id=2,
                    Name="SHYAM"
                },
                new Villa
                {
                    Id=3,
                    Name="HARI"
                }


            };
        }
    }
}
 