using EasyCashIdentityProject.EntityLayer.Concrete;
using EasyCashIdentityProject.PresentationLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentityProject.PresentationLayer.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInMagager;
        private readonly UserManager<AppUser> _userManager;

        public LoginController(SignInManager<AppUser> signInMagager, UserManager<AppUser> userManager)
        {
            _signInMagager = signInMagager;
            _userManager = userManager;
        }

        [HttpGet] 
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel loginViewModel)
        {
            var result = await _signInMagager.PasswordSignInAsync(loginViewModel.UserName, loginViewModel.Password, true, true);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(loginViewModel.UserName);
                if (user.EmailConfirmed == true)
                {
                    return RedirectToAction("Index", "MyProfile");
                }
            }
            return View();
        }
    }
}
