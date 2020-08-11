using api.Domain.Models;

namespace api.Domain.Services.Communication {
    public class CityResponse : BaseResponse {
        public City City {get; private set;}

        private CityResponse(bool success, string message, City city) : base(success, message)
        {
            City = city;
        }

        //Cria uma resposta de sucesso de operacao        
        public CityResponse(City city): this(true, string.Empty, city)
        {            
        }

        //Cria uma resposta de erro de operacao
        public CityResponse(string message): this(false, message, null)
        {

        }
    }
}