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

namespace HotelListingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly HotelDbContext _context;
        private readonly IMapper _mapper;

        public CountriesController(HotelDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Countries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetCountriesDTO>>> GetCountries()
        {
            if (_context.Countries == null)
            {
                return NotFound();
            }
            var countries = await _context.Countries.ToListAsync();

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
            if (_context.Countries == null)
            {
                return NotFound();
            }

            var country = await _context.Countries
                                    .Include(q => q.Hotels)
                                    .FirstOrDefaultAsync(s => s.CountryId == id);

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
            var country = await _context.Countries.FindAsync(id);

            if (country == null)
            {
                return NotFound();
            }

            // Assign the input DTO values to the found country item:
            _mapper.Map(updateCountryDTO, country);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountryExists(id))
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
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
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

            if (_context.Countries == null)
            {
                  return Problem("Entity set 'HotelDbContext.Countries'  is null.");
            }
            _context.Countries.Add(country);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCountry", new { id = country.CountryId }, country);
        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            if (_context.Countries == null)
            {
                return NotFound();
            }
            var country = await _context.Countries.FindAsync(id);
            if (country == null)
            {
                return NotFound();
            }

            _context.Countries.Remove(country);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CountryExists(int id)
        {
            return (_context.Countries?.Any(e => e.CountryId == id)).GetValueOrDefault();
        }
    }
}
