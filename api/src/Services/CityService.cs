using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using api.Domain.Models;
using api.Domain.Services;
using api.Domain.Repositories;
using api.Domain.Services.Communication;

namespace api.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepo;
        private readonly IUnitOfWork _unitOfWork;

        public CityService(ICityRepository cityRepository, IUnitOfWork unitOfWork) {
            this._cityRepo = cityRepository;
            this._unitOfWork = unitOfWork;
        }        

        public async Task<IEnumerable<City>> ListAsync()
        {
            return await _cityRepo.ListAsync();
        }

        public async Task<City> FindById(long id)
        {
            return await _cityRepo.FindByIdAsync(id);
        }

        public async Task<IEnumerable<City>> FindByPattern(string pattern)
        {
            return await _cityRepo.FindByPatternAsync(pattern);
        }

        public async Task<CityResponse> SaveAsSync(City city)
        {
            try
            {
                await _cityRepo.AddAsync(city);            
                await _unitOfWork.CompleteAsync();
                return new CityResponse(city);
            }
            catch (Exception ex) {
                return new CityResponse($"Ocorreu um erro: {ex.Message}");
            }            
        }

        public async Task<CityResponse> UpdateAsync(long id, City city)
        {
            var existingCity = await _cityRepo.FindByIdAsync(id);
            if (existingCity == null) {
                return new CityResponse("Cidade não encontrada");
            }

            existingCity.Cidade = city.Cidade;
            existingCity.Ibge = city.Ibge;
            existingCity.Uf = city.Uf;
            existingCity.Regiao = city.Regiao;
            existingCity.Latitude = city.Latitude;
            existingCity.Longitude = city.Longitude;

            try
            {
                _cityRepo.Update(existingCity);
                await _unitOfWork.CompleteAsync();
                return new CityResponse(existingCity);                
            }
            catch (Exception ex) {
                return new CityResponse($"Ocorreu um erro: {ex.Message}");
            }
        }

        public async Task<CityResponse> DeleteAsync(long id)
        {
            var existingCity = await _cityRepo.FindByIdAsync(id);
            if (existingCity == null) {
                return new CityResponse("Cidade não encontrada");
            }
            try
            {
                _cityRepo.Remove(existingCity);
                await _unitOfWork.CompleteAsync();
                return new CityResponse(existingCity);
            }
            catch (Exception ex)
            {
                return new CityResponse($"Ocorreu um erro: {ex.Message})");
            }
        }
        
    }
}