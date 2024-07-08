namespace TravelProject.Models
{
    public class Image
    {
        public int ImageId { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public int TouristSpotId { get; set; }
        public TouristSpot? TouristSpot { get; set; }
    }
}