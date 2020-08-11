using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using api.Domain.Models;
using api.Domain.Services;
using api.Resources;
using api.Extensions;


namespace api.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class CitiesController: Controller
    {
        private readonly ICityService _cityService;
        private readonly IMapper _mapper;

        public CitiesController(ICityService service, IMapper mapper) {
            _cityService = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CityResource>> Get() {
            var cities =  await _cityService.ListAsync();
            var resources = _mapper.Map<IEnumerable<City>, IEnumerable<CityResource>>(cities);
            return resources;
        }

        [HttpGet("{id}")]
        public async Task<CityResource> Get(long id) {
            var city = await _cityService.FindById(id);
            var resource = _mapper.Map<City, CityResource>(city);
            return resource;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SaveCityResource resource) {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var city = _mapper.Map<SaveCityResource, City>(resource);
            
            var result = await _cityService.SaveAsSync(city);
            if (!result.Success) {
                return BadRequest(result.Message);
            }
            var cityResource = _mapper.Map<City, CityResource>(result.City);
            return Ok(cityResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] SaveCityResource resource) {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var city = _mapper.Map<SaveCityResource, City>(resource);
            var result = await _cityService.UpdateAsync(id, city);

            if (!result.Success) {
                return BadRequest(result.Message);
            }

            var cityResource = _mapper.Map<City, CityResource>(result.City);
            return Ok(cityResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _cityService.DeleteAsync(id);

            if (!result.Success) 
                return BadRequest(result.Message);
            
            var cityResource = _mapper.Map<City, CityResource>(result.City);
            return Ok(cityResource);
        }
        
    }
}