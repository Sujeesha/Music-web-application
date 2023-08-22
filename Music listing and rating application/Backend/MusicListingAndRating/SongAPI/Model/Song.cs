namespace SongAPI.Model
{
    public class Song
    {
        public int Id { get; set; } 
        public string Title { get; set; }
        public string Artist { get; set; }
        public string album { get; set;}
        public string Genre { get; set;}
        public string Language { get; set;}
        public string FilePath { get; set; }
        public double AverageRating { get; set; }

        public int TotalRatings { get; set; }

    }
}
