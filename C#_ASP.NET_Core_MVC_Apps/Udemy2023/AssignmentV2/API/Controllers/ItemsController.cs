using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;
using AutoMapper;
using API.Models.DTOs;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly Assignment2023Context _context;
        private readonly IMapper _mapper;

        public ItemsController(Assignment2023Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Items
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetCreateItemDTO>>> GetItems()
        {
            if (_context.Items == null)
            {
                return NotFound();
            }

            var itemsList = await _context.Items.ToListAsync();

            List<GetCreateItemDTO> itemDTOlist = _mapper.Map<List<GetCreateItemDTO>>(itemsList);

            return Ok(itemDTOlist);
        }

        // GET: api/Items/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetCreateItemDTO>> GetItem(int id)
        {
            if (_context.Items == null)
            {
                return NotFound();
            }

            var item = await _context.Items.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            var itemDTO = _mapper.Map<GetCreateItemDTO>(item);

            return Ok(itemDTO);
        }

        // PUT: api/Items/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItem(int id, UpdateItemDTO updateItemDTO)
        {
            if (id != updateItemDTO.ItemId)
            {
                return BadRequest("Invalid ItemID was used in this PUT HTTP request.");
            }

            //_context.Entry(item).State = EntityState.Modified;

            // Ensure that this specific Item is found and changes in it are tracked:
            var item = await _context.Items.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            // Assign the input DTO values to the found Item:
            _mapper.Map(updateItemDTO, item);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExists(id))
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

        // POST: api/Items
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Item>> PostItem(GetCreateItemDTO createItemDTO)
        {
            var item = _mapper.Map<Item>(createItemDTO);

            if (_context.Items == null)
            {
                return Problem("Entity set 'Assignment2023Context.Items'  is null.");
            }

            _context.Items.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItem", new { id = item.ItemId }, item);
        }

        // DELETE: api/Items/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            if (_context.Items == null)
            {
                return NotFound();
            }

            var item = await _context.Items.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            _context.Items.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ItemExists(int id)
        {
            return (_context.Items?.Any(e => e.ItemId == id)).GetValueOrDefault();
        }
    }
}
