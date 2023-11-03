using EasyCashIdentityProject.EntityLayer.Concrete;
using EasyCashIdentityProject.PresentationLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentityProject.PresentationLayer.Controllers
{
    public class ConfirmMailsController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ConfirmMailsController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var value = TempData["Mail"];
            ViewBag.v = value;
            //confirmMailViewModel.Mail = value.ToString();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(ConfirmMailViewModel confirmMailViewMode)
        {
            
            var user = await _userManager.FindByEmailAsync(confirmMailViewMode.Mail);
            if (user.ConfirmCode == confirmMailViewMode.ConfirmCode) 
            {
                user.EmailConfirmed= true;
                await _userManager.UpdateAsync(user);
                return RedirectToAction("Index", "MyProfile");
            }
            return View();
        }
    }
}
