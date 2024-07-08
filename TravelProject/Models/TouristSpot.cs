namespace TravelProject.Models
{
    public class TouristSpot
    {
        public int TouristSpotId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int CityId { get; set; }
        public City? City { get; set; }
        public ICollection<Favorite>? Favorites { get; set; }
    }
}