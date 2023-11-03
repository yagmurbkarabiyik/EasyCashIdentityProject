using EasyCashIdentityProject.DtoLayer.Dtos.AppUserDtos;
using EasyCashIdentityProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Policy;

//myAccounts
namespace EasyCashIdentityProject.PresentationLayer.Controllers
{
    public class MyProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public MyProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }



        [HttpGet]
        [Route("Myprofile/UpdateProfile")]
        public async Task<IActionResult> UpdateProfile()
        {
            AppUserEditDto dto = new AppUserEditDto();
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            dto.PhoneNumber = user.PhoneNumber;
            dto.Surname = user.Surname;
            dto.Name = user.Name;
            dto.City = user.City;
            dto.District= user.District;
            dto.Email= user.Email;

            return View(dto);
        }

        [HttpPost]
        [Route("Myprofile/UpdateProfile")]
        public async Task<IActionResult> UpdateProfile(AppUserEditDto dto)
        {
           
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            user.PhoneNumber =dto.PhoneNumber;
                user.Surname = dto.Surname;
                user.Name = dto.Name;
                user.City = dto.City;
                user.District = dto.District;
                user.Email = dto.Email;

           var result = await _userManager.UpdateAsync(user);
            
            if (result.Succeeded)
            {
                return View(dto);
            }
            

            return View(dto);

        }


        [HttpGet]
        public async Task<IActionResult> Index(string email = null)
        {
            if (email != null)
            {
                var values = await _userManager.FindByEmailAsync(email);
                AppUserEditDto appUserEditDto = new AppUserEditDto();
                appUserEditDto.Name = values.Name;
                appUserEditDto.Surname = values.Surname;
                appUserEditDto.PhoneNumber = values.PhoneNumber;
                appUserEditDto.Email = values.Email;
                appUserEditDto.City = values.City;
                appUserEditDto.District = values.District;
                return View(appUserEditDto);
            }
            else
            {
                var values = await _userManager.FindByNameAsync(User.Identity?.Name);
                AppUserEditDto appUserEditDto = new AppUserEditDto();
                appUserEditDto.Name = values.Name;
                appUserEditDto.Surname = values.Surname;
                appUserEditDto.PhoneNumber = values.PhoneNumber;
                appUserEditDto.Email = values.Email;
                appUserEditDto.City = values.City;
                appUserEditDto.District = values.District;
                return View(appUserEditDto);
            }
           
        }

        [HttpPost]
        public async Task<IActionResult> Index(AppUserEditDto appUserEditDto)
        {
            if (appUserEditDto.Password == appUserEditDto.ConfirmPasword)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                user.PhoneNumber = appUserEditDto.PhoneNumber;
                user.Surname = appUserEditDto.Surname;
                user.Name = appUserEditDto.Name;
                user.District = appUserEditDto.District;
                user.Email = appUserEditDto.Email;
                user.City = appUserEditDto.City;
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, appUserEditDto.Password);
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Login");
                }
            }
            return View();
            
        }
    }
}
