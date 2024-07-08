namespace TravelProject.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public int Rating { get; set; }
        public string Comments { get; set; }
        public string UserId { get; set; }
        public User? User { get; set; }
        public int TouristSpotId { get; set; }
        public TouristSpot? TouristSpot { get; set; }
    }
}