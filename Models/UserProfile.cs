using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication10Jan20Country.Models
{
    public class UserProfile
    {
        [Key]
        public int UserProfileID { get; set; }

        [ForeignKey("IdentityUser")]
        public string UserID { get; set; }

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;


        public DateTime? DateOfBirth { get; set; }


        [ValidateNever]
        [NotMapped]
        public string UserName { get; set; }

        [ValidateNever]
        [NotMapped]
        public string Email { get; set; }

        [ValidateNever]
        [NotMapped]

        public string PhoneNumber { get; set; }

        [ValidateNever]
        public IdentityUser IdentityUser { get; set; }
    }
}
