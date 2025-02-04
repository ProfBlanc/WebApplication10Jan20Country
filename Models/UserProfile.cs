using Microsoft.AspNetCore.Identity;

namespace WebApplication10Jan20Country.Models
{
    public class UserProfile : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public DateTime? DateOfBirth { get; set; }


    }
}
