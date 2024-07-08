using Microsoft.AspNetCore.Identity;

namespace TravelProject.Models
{
    public class User : IdentityUser
    {
        public string? Role { get; set; }
        public ICollection<Favorite>? Favorites { get; set; }
    }
}