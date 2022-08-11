using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FriendMusic.Data;
using FriendMusic.Models;
using FriendMusic.DTO;

namespace FriendMusic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistsController : ControllerBase
    {
        private readonly FMContext _context;
        private readonly ILogger<PlaylistsController> _logger;

        public PlaylistsController(ILogger<PlaylistsController> logger, FMContext context)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/Playlists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Playlist>>> GetPlaylists()
        {
          if (_context.Playlists == null)
          {
              return NotFound();
          }
            return await _context.Playlists.ToListAsync();
        }

        // GET: api/Playlists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlaylistDetailsDTO>> GetPlaylist(int id)
        {
          if (_context.Playlists == null)
          {
              return NotFound();
          }
            var playlist = await _context.Playlists.FindAsync(id);

            if (playlist == null)
            {
                return NotFound();
            }
            var owners = await _context.People.Where(p => p.OwnedPlaylists.Where(op => op.PlaylistId == playlist.Id).Any()).ToListAsync();
            var likes = await _context.People.Where(p => p.LikedPlaylists.Where(op => op.PlaylistId == playlist.Id).Any()).ToListAsync();
            var songs = await _context.Songs.Where(p => p.AppearsOnPlaylists.Where(aop => aop.PlaylistId == playlist.Id).Any()).ToListAsync();

            var pdDto = new PlaylistDetailsDTO
            {
                Id = playlist.Id,
                Name = playlist.Name,
                Description = playlist.Description,
                SongCount = playlist.SongCount,
                LikesCount = playlist.LikesCount,
                Owners = owners,
                Likes = likes,
                Songs = songs
            };

            return Ok(pdDto);
        }

        // PUT: api/Playlists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlaylist(int id, Playlist playlist)
        {
            if (id != playlist.Id)
            {
                return BadRequest();
            }

            _context.Entry(playlist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlaylistExists(id))
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

        // POST: api/Playlists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Playlist>> PostPlaylist(PlaylistDTO dto)
        {
          if (_context.Playlists == null)
          {
              return Problem("Entity set 'FMContext.Playlists'  is null.");
          }
            var playlist = new Playlist(dto);
            _context.Playlists.Add(playlist);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlaylist", new { id = playlist.Id }, playlist);
        }

        // DELETE: api/Playlists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlaylist(int id)
        {
            if (_context.Playlists == null)
            {
                return NotFound();
            }
            var playlist = await _context.Playlists.FindAsync(id);
            if (playlist == null)
            {
                return NotFound();
            }

            _context.Playlists.Remove(playlist);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlaylistExists(int id)
        {
            return (_context.Playlists?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
