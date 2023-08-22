using SongAPI.Data;
using SongAPI.Model;

namespace SongAPI.Services
{
    public class SongService : ISongRepository
    {

        private readonly DbContextClass _dbContext;
        public SongService(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Song> GetProductList()
        {
            return _dbContext.Songs.ToList();
        }
        public Song GetSong(int id)
        {

            return _dbContext.Songs.Where(song => song.Id == id).FirstOrDefault();
        }
        public Song AddSong(Song song)
        {
            var result = _dbContext.Songs.Add(song);

            _dbContext.SaveChanges();

            return result.Entity;
        }
        public void UpdateSong(int id, Song song)
        {
            var existingSong = _dbContext.Songs.FirstOrDefault(song => song.Id == id);
            if (existingSong != null)
            {
                existingSong.Title = song.Title;
                existingSong.Artist = song.Artist;
                existingSong.album = song.album;
                existingSong.Genre = song.Genre;
                existingSong.Language = song.Language;
                existingSong.FilePath = song.FilePath;
                existingSong.AverageRating = song.AverageRating;
                _dbContext.SaveChanges();

            }
        }
        public void DeleteSong(int id)
        {
            var existingSong = _dbContext.Songs.FirstOrDefault(song => song.Id == id);
            if (existingSong != null)
            {
                _dbContext.Songs.Remove(existingSong);
                _dbContext.SaveChanges();
            }
        }
        public IEnumerable<Song> SearchSongs(string keyword)

        {

            keyword = keyword.ToUpper(); // Convert the keyword to uppercase for case-insensitive search

            return _dbContext.Songs

              .Where(s => s.Title.ToUpper().Contains(keyword) ||

                    s.Artist.ToUpper().Contains(keyword) ||

                    s.album.ToUpper().Contains(keyword) ||

                    s.Genre.ToUpper().Contains(keyword));

        }
        public void AddRating(int songId, int rating)

        {

            var song = _dbContext.Songs.FirstOrDefault(s => s.Id == songId);

            if (song != null)

            {

                song.TotalRatings++;

                song.AverageRating = ((song.AverageRating * (song.TotalRatings - 1)) + rating) / song.TotalRatings;

                _dbContext.SaveChanges();
            }
        }
    }
}
