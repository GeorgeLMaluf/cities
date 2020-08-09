using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using api.Domain.Models;
using api.Domain.Services;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class CitiesController: Controller
    {
        private readonly ICityService _cityService;

        public CitiesController(ICityService service) {
            _cityService = service;
        }

        [HttpGet]
        public async Task<IEnumerable<City>> Get() {
            var cities =  await _cityService.ListAsync();
            return cities;
        }

        //private readonly CityContext _cityctx;

        // public CitiesController(CityContext ctx) {
        //     //_cityctx = ctx;
        // }

        // [HttpGet]
        // public ActionResult<IEnumerable<City>> Get() {
        //     //return _cityctx.Cities.ToList();
        // }

        // [HttpGet("{id}")]
        // public ActionResult<City> Get(int id) {
        //     // try {
        //     //     var city = _cityctx.Cities.Where(x => x.Id == id).First();
        //     //     return city;
        //     // }
        //     // catch (Exception){
        //     //     return null;
        //     // }            
        // }

        // [HttpPost]
        // public void Post([FromBody] City value) {
        //     //
        // }

        // [HttpPut("{id}")]
        // public void Put(int id, [FromBody] City value)
        // {
        //     //
        // }

        // [HttpDelete("{id}")]
        // public void Delete(int id) {
        //     //
        // }
    }
}