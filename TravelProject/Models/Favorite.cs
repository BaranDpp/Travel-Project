namespace TravelProject.Models
{
    public class Favorite
    {
        public int FavoriteId { get; set; }
        public string UserId { get; set; }
        public User? User { get; set; }
        public int TouristSpotId { get; set; }
        public TouristSpot? TouristSpot { get; set; }
    }
}