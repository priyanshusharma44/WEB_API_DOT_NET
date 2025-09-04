using AutoMapper;
using WEB_API_DOT_NET.Models;
using WEB_API_DOT_NET.Models.DTO;

namespace WEB_API_DOT_NET
{
    public class MappingConfig: Profile
    {
        public MappingConfig() 
        {
           CreateMap<Villa,VillaDTO>().ReverseMap();
            CreateMap<Villa, VillaCreateDTO>().ReverseMap();
            CreateMap<Villa,VillaUpdateDTO>().ReverseMap();
        
        
        }

    }
}
