using SongAPI.Model;

namespace SongAPI.Services
{
    public interface ISongRepository
    {
        public IEnumerable<Song> GetProductList();
        public Song GetSong(int Id);
        public Song AddSong(Song song);
        public void UpdateSong(int id,Song song);
        public void DeleteSong(int Id);
        public IEnumerable<Song> SearchSongs(string keyword);
        public void AddRating(int songId, int rating);
    }
}
