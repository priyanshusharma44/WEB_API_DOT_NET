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
                    Name="RAM",
                    Description = "ABC"
                },
                new VillaDTO
                {
                    Id=2,
                    Name="SHYAM",
                    Description = "DEF"
                },
                new VillaDTO
                {
                    Id=3,
                    Name="HARI",
                    Description = "GHI"
                }

            };
    }
}
