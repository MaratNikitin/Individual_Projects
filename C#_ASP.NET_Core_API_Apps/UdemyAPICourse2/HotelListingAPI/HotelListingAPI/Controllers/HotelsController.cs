using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelListingAPI.Data;
using HotelListingAPI.Contracts;
using AutoMapper;
using HotelListingAPI.Data.DTOs;

namespace HotelListingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelsRepository _hotelsRepository;
        private readonly IMapper _mapper;

        public HotelsController(IHotelsRepository hotelsRepository, IMapper mapper)
        {
            this._hotelsRepository = hotelsRepository;
            this._mapper = mapper;
        }

        // GET: api/Hotels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetHotelsDTO>>> GetHotels()
        {
            if (_hotelsRepository == null)
            {
                return NotFound();
            }

            var hotels = await _hotelsRepository.GetAllAsync();
            var hotelsDTO = _mapper.Map<List<GetHotelsDTO>>(hotels);

            return hotelsDTO;
        }

        // GET: api/Hotels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetHotelsDTO>> GetHotel(int id)
        {
            if (_hotelsRepository == null)
            {
                return NotFound();
            }

            var hotel = await _hotelsRepository.GetAsync(id);

            if (hotel == null)
            {
                return NotFound();
            }

            var hotelDTO = _mapper.Map<GetHotelsDTO>(hotel);

            return Ok(hotelDTO);
        }

        // PUT: api/Hotels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotel(int id, UpdateHotelDTO hotelDTO)
        {
            if (id != hotelDTO.HotelId)
            {
                return BadRequest();
            }

            var hotel = await _hotelsRepository.GetAsync(id);

            _mapper.Map(hotelDTO, hotel);

            try
            {
                await _hotelsRepository.UpdateAsync(hotel);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (! await HotelExists(id))
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

        // POST: api/Hotels
        [HttpPost]
        public async Task<ActionResult<Hotel>> PostHotel(CreateHotelDTO createHotelDTO)
        {
            var hotel = _mapper.Map<Hotel>(createHotelDTO);
            if (_hotelsRepository == null)
            {
                return Problem("Entity set 'HotelDbContext.Hotels'  is null.");
            }

            await _hotelsRepository.AddAsync(hotel);

            return CreatedAtAction("GetHotel", new { id = hotel.HotelId }, hotel);
        }

        // DELETE: api/Hotels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            if (_hotelsRepository == null)
            {
                return NotFound();
            }

            var hotel = await _hotelsRepository.GetAsync(id);

            if (hotel == null)
            {
                return NotFound();
            }

            await _hotelsRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> HotelExists(int id)
        {
            return await _hotelsRepository.Exists(id);
        }
    }
}
