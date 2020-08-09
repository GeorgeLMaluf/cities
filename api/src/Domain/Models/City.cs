using System.ComponentModel.DataAnnotations;

namespace api.Domain.Models
{
    public class City {

        public long Id {get;set;}

        [Required]
        public int Ibge {get;set;}
        
        [Required, StringLength(2)]
        public string Uf {get;set;}

        [Required, StringLength(80)]
        public string Cidade {get;set;}

        [Required, StringLength(25)]
        public string Longitude {get;set;}

        [Required, StringLength(25)]
        public string Latitude {get;set;}
        [Required, StringLength(60)]
        public string Regiao {get;set;}
    }
}