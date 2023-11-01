using EasyCashIdentityProject.BusinessLayer.Abstract;
using EasyCashIdentityProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentityProject.BusinessLayer.Concrete
{
    public class AccountProcessManager : IAccountProcessService
    {
        private readonly IAccountProcessService _accountProcessService;

        public AccountProcessManager(IAccountProcessService accountProcessService)
        {
            _accountProcessService = accountProcessService;
        }

        public void TDelete(AccountProcess t)
        {
            _accountProcessService.TDelete(t);
        }

        public void TGetById(AccountProcess t)
        {
            _accountProcessService.TGetById(t);
        }

        public List<AccountProcess> TGetList()
        {
            return _accountProcessService.TGetList();
        }

        public void TInsert(AccountProcess t)
        {
            _accountProcessService.TInsert(t);  
        }

        public void TUpdate(AccountProcess t)
        {
            _accountProcessService.TUpdate(t);
        }
    }
}
