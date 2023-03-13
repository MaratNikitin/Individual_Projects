using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelListingAPI.Data;
using HotelListingAPI.Data.DTOs;
using AutoMapper;
using HotelListingAPI.Contracts;

namespace HotelListingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICountriesRepository _countriesRepository;

        public CountriesController(IMapper mapper, ICountriesRepository countriesRepository)
        {
            _mapper = mapper;
            this._countriesRepository = countriesRepository;
        }

        // GET: api/Countries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetCountriesDTO>>> GetCountries()
        {
            var countries = await _countriesRepository.GetAllAsync();

            //// Looping though a list manually is one option:
            //List<GetCountryDTO> countryDTOList = new();   
            //foreach (var country in countries)
            //{
            //    GetCountryDTO countryDTO = _mapper.Map<GetCountryDTO>(country);
            //    countryDTOList.Add(countryDTO);
            //}

            // This line below is an elegant way of mapping a list into a list:
            List<GetCountriesDTO> countryDTOList = _mapper.Map<List<GetCountriesDTO>>(countries);

            return Ok(countryDTOList); 
        }

        // GET: api/Countries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetCountryDetailsDTO>> GetCountry(int id)
        {
            var country = await _countriesRepository.GetDetails(id);

            if (country == null)
            {
                return NotFound();
            }

            var countryDTO = _mapper.Map<GetCountryDetailsDTO>(country);

            return Ok(countryDTO);
        }

        // PUT: api/Countries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountry(int id, UpdateCountryDTO updateCountryDTO)
        {
            if (id != updateCountryDTO.CountryId)
            {
                return BadRequest("Invalid CountryId was used in this Put request.");
            }

            // _context.Entry(country).State = EntityState.Modified;

            // Ensure that this specific Country item is tracked:
            var country = await _countriesRepository.GetAsync(id);

            if (country == null)
            {
                return NotFound();
            }

            // Assign the input DTO values to the found country item:
            _mapper.Map(updateCountryDTO, country);

            try
            {
                await _countriesRepository.UpdateAsync(country);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (! await CountryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Countries
        [HttpPost]
        public async Task<ActionResult<Country>> PostCountry(CreateCountryDTO createCountryDTO)
        {

            //// Direct mapping (i.e. avoiding AutoMapper) example is below:
            //var country = new Country
            //{
            //    CountryName = createCountryDTO.CountryName,
            //    CountryShortName = createCountryDTO.CountryShortName
            //};

            // using AutoMapper to covert DTO to the entity class Country:
            var country = _mapper.Map<Country>(createCountryDTO);

            if (_countriesRepository == null)
            {
                  return Problem("Entity set 'HotelDbContext.Countries'  is null.");
            }

            await _countriesRepository.AddAsync(country);

            return CreatedAtAction("GetCountry", new { id = country.CountryId }, country);
        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            if (_countriesRepository == null)
            {
                return NotFound();
            }

            var country = await _countriesRepository.GetAsync(id);

            if (country == null)
            {
                return NotFound();
            }

            await _countriesRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> CountryExists(int id)
        {
            return await _countriesRepository.Exists(id);
        }
    }
}
