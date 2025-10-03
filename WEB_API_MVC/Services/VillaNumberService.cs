    using Villa_Utility;
    using WEB_API_MVC.Models;
    using WEB_API_MVC.Models.DTO;
    using WEB_API_MVC.Services.IServices;

    namespace WEB_API_MVC.Services
    {
        public class VillaNumberService : BaseService, IVillaNumberService
    {
            private readonly IHttpClientFactory _clientFactory;
            private string villaUrl;
            public VillaNumberService(IHttpClientFactory clientFactory, IConfiguration configuration): base(clientFactory) 
            {
                _clientFactory = clientFactory;
                villaUrl = configuration.GetValue<string>("ServiceUrls:VillaAPI");
            }

            public Task<T> CreateAsync<T>(VillaNumberCreateDTO dto)
            {
                return SendAsync<T>(new ApiRequest
                {
                    ApiType = SD.ApiType.POST,   
                    Data = dto,                  
                    Url = $"{villaUrl}/api/VillaNumberAPI"
                });
            }


            public Task<T> DeleteAsync<T>(int id)
            {
                return SendAsync<T>(new ApiRequest
                {
                    ApiType = SD.ApiType.DELETE,
                
                    Url = $"{villaUrl}/api/VillaNumberAPI/{id}"
                });

            }

            public Task<T> GetAllAsync<T>()
            {
                return SendAsync<T>(new ApiRequest
                {
                    ApiType = SD.ApiType.GET,
                    Url = $"{villaUrl}/api/VillaAPI"
                });
            }

            public Task<T> GetAsync<T>(int id)
            {
                return SendAsync<T>(new ApiRequest
                {
                    ApiType = SD.ApiType.GET,
                    Url = $"{villaUrl}/api/VillaAPI/{id}"
                });
            }

         

        public Task<T> UpdateAsync<T>(VillaNumberUpdateDTO dto)
        {
            return SendAsync<T>(new ApiRequest

            {
                ApiType = SD.ApiType.PUT,
                Data = dto,
                Url = $"{villaUrl}/api/VillaAPI/{dto.VillaNo}"
            });
        }
    }
    }
 