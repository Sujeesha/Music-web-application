using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SongAPI.Model;
using SongAPI.Services;
using System.Data;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace SongAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongController : ControllerBase
    {
        private readonly ISongRepository _repository;
        public SongController(ISongRepository repository)
        {
            _repository = repository;
        }
        //[Authorize(Roles = "Admin")] // Replace "Admin" with your actual role name
        //[Authorize(Roles = UserRoles.Admin)]
        [HttpPost]
        [Route("Add")]
        public ActionResult<Song> AddAudio(Song song)
        {
            var addedSong = _repository.AddSong(song);
            return CreatedAtAction(nameof(ViewAudioDetails), new { id = addedSong.Id }, addedSong);
        }
        [HttpPut("update/{id}")]
        public IActionResult EditAudio(int id, Song song)
        {
            var existingSong = _repository.GetSong(id);
            if (existingSong == null)
                return NotFound();
            _repository.UpdateSong(id, song);
            return NoContent();
        }
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteAudio(int id)
        {
            var existingSong = _repository.GetSong(id);
            if (existingSong == null)
                return NotFound();
            _repository.DeleteSong(id);
            return NoContent();
        }
        [HttpGet("get/{id}")]
        public ActionResult<Song> ViewAudioDetails(int id)
        {
            var song = _repository.GetSong(id);
            if (song == null)
                return NotFound();
            return Ok(song);
        }
        [HttpGet("search")]
        public ActionResult<IEnumerable<Song>> SearchSongs([FromQuery] string keyword)
        {

            var songs = _repository.SearchSongs(keyword);
            return songs.ToList();
        }
        [HttpPost("rate/{id}")]

        public IActionResult RateSong(int id, [FromBody] int rating)

        {
            if (rating < 1 || rating > 5)
            {
                return BadRequest("Rating must be between 1 and 5.");
            }
            _repository.AddRating(id, rating);
            return Ok("Rating added successfully.");
        }
        //[Authorize(Roles = UserRoles.Admin)]
        [HttpGet]
        public ActionResult<IEnumerable<Song>> ViewAllAudioDetails()
        {
            var songs = _repository.GetProductList();
            return songs.ToList();
        }
    }
}
