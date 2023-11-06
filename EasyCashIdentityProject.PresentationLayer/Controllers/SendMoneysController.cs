using EasyCashIdentityProject.DataAccessLayer.Concrete;
using EasyCashIdentityProject.DtoLayer.Dtos.CustomerAccountDtos;
using EasyCashIdentityProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentityProject.PresentationLayer.Controllers
{
    public class SendMoneysController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ICustomerAccountProcessService _customerAccountProcessService;

        public SendMoneysController(UserManager<AppUser> userManager, ICustomerAccountProcessService customerAccountProcessService)
        {
            _userManager = userManager;
            _customerAccountProcessService = customerAccountProcessService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Index(CreateDto createDto)
        {
            var context = new Context();
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var receiverAccountNumber = context.CustomerAccounts.Where(x => x.AccountNumber == createDto.ReceiverAccountNumber)
               .Select(y => y.Id).FirstOrDefault();
            createDto.SenderId = user.Id;
            createDto.ReceiverId = receiverAccountNumber;
            createDto.ProcessDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            createDto.ProcessType = "Deneme";
           
           
            return View();
        }
    }
}
