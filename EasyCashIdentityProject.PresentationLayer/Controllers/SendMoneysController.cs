using EasyCashIdentityProject.BusinessLayer.Abstract;
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
        private readonly ICustomerAccountService _customerAccountProcessService;

        public SendMoneysController(UserManager<AppUser> userManager, ICustomerAccountService customerAccountProcessService)
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

            var senderAccountNumberId = context.CustomerAccounts.Where(x => x.AppUserId == user.Id)
                .Where(y => y.AccountCurrency == "Türk Lirası")
                .Select(z => z.Id);


            var values = new AccountProcess();
            values.ProcessDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            values.SenderId = 1;
            values.ReceiverId = receiverAccountNumber;
            values.Amount = createDto.Amount;
            values.ProcessType = "Havale";

           // _customerAccountProcessService.TInsert(values);
            return RedirectToAction("Index", "Deneme");
        }

      
    }
}
