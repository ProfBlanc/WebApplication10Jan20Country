using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication10Jan20Country.Models;

namespace WebApplication10Jan20Country.Controllers
{
    public class UserProfileController : Controller
    {
        private readonly UserManager<UserProfile> _userManager;

        public UserProfileController(UserManager<UserProfile> userManager) {

            _userManager = userManager;
        }

        public IActionResult Index()
        {
           
            return View(_userManager.GetUserAsync(User));
        }

        [HttpPost]
        public IActionResult Index([Bind("Username,Email,PhoneNumber,FirstName,LastName,DateOfBirth")] UserProfile userProfile) { 
        
            return View();
        }

    }
}
