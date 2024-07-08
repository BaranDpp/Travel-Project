namespace TravelProject.Models
{
    public class Visit
    {
        public int VisitId { get; set; }
        public DateTime VisitDate { get; set; }
        public string Comments { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public int TouristSpotId { get; set; }
        public TouristSpot? TouristSpot { get; set; }
    }
}