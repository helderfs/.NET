﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIVenda_BD.Data;
using APIVenda_BD.Models;
using Microsoft.AspNetCore.Authorization;

namespace APIVenda_BD.Controllers
{
    [Authorize]
    //[Route("api/[controller]")]
    [Route("[controller]")]
    [ApiController]
    public class VendasController : ControllerBase
    {
        private readonly ApiContextDB _context;

        public VendasController(ApiContextDB context)
        {
            _context = context;
        }

        [Authorize]
        // GET: api/Vendas
        [HttpGet("grafico")]
        public async Task<ActionResult<IEnumerable<VendasMod>>> GetVendasMod()
        {
            return await _context.VendasMod.ToListAsync();
        }

        [Authorize]
        // GET: api/Vendas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VendasMod>> GetVendasMod(int id)
        {
            var vendasMod = await _context.VendasMod.FindAsync(id);

            if (vendasMod == null)
            {
                return NotFound();
            }

            return vendasMod;
        }

        // PUT: api/Vendas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVendasMod(int id, VendasMod vendasMod)
        {
            if (id != vendasMod.Codigo)
            {
                return BadRequest();
            }

            _context.Entry(vendasMod).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VendasModExists(id))
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

        // POST: api/Vendas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<VendasMod>> PostVendasMod(VendasMod vendasMod)
        {
            _context.VendasMod.Add(vendasMod);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVendasMod", new { id = vendasMod.Codigo }, vendasMod);
        }

        // DELETE: api/Vendas/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVendasMod(int id)
        {
            var vendasMod = await _context.VendasMod.FindAsync(id);
            if (vendasMod == null)
            {
                return NotFound();
            }

            _context.VendasMod.Remove(vendasMod);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VendasModExists(int id)
        {
            return _context.VendasMod.Any(e => e.Codigo == id);
        }
    }
}
