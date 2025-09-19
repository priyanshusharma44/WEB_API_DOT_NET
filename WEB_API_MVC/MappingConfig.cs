using AutoMapper;
using WEB_API_MVC.Models.DTO;
namespace WEB_API_MVC
{
    public class MappingConfig: Profile
    {
        public MappingConfig() 
        {

            CreateMap<VillaDTO, VillaCreateDTO>().ReverseMap();
            CreateMap<VillaDTO,VillaUpdateDTO>().ReverseMap();

            CreateMap<VillaNumberDTO,VillaNumberDTO>().ReverseMap();
            CreateMap<VillaNumberDTO,VillaNumberCreateDTO>().ReverseMap();
            CreateMap<VillaNumberDTO, VillaNumberUpdateDTO>().ReverseMap();
        
        
        }

    } 
}
