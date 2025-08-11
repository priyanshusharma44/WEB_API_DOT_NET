using WEB_API_DOT_NET.Models.DTO;

namespace WEB_API_DOT_NET.Data
{
    public static class VillaStore
    {
        public static List<VillaDTO> villaList = new List<VillaDTO>
            {
                new VillaDTO
                {
                    Id=1,
                    Name="RAM"
                },
                new VillaDTO
                {
                    Id=2,
                    Name="SHYAM"
                },
                new VillaDTO
                {
                    Id=3,
                    Name="HARI"
                }


            };
    }
}
