namespace TravelProject.Models
{
    public class City
    {
        public int CityId { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<TouristSpot>? TouristSpots { get; set; }
    }
}