using AutoMapper;
using api.Domain.Models;
using api.Resources;

namespace api.Mapping {
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile() {
            CreateMap<City, CityResource>();
        }
    }
}