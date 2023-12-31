﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentityProject.EntityLayer.Concrete
{
    public class CustomerAccount
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public string AccountCurrency { get; set; }
        public decimal AccountBalance { get; set; }
        public string BankBranch { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public List<AccountProcess> CustomerSender { get; set; }
        public List<AccountProcess> CustomerReceiver { get; set; }

    }
}

