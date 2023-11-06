using EasyCashIdentityProject.DataAccessLayer.Abstract;
using EasyCashIdentityProject.DataAccessLayer.Repositories;
using EasyCashIdentityProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentityProject.DataAccessLayer.EntityFramework
{
    public class EfCustomerAccountProcessDal : GenericRepository<AccountProcess>, ICustomerAccountDal
    {
        public void Delete(CustomerAccount t)
        {
            throw new NotImplementedException();
        }

        public void Insert(CustomerAccount t)
        {
            throw new NotImplementedException();
        }

        public void Update(CustomerAccount t)
        {
            throw new NotImplementedException();
        }

        CustomerAccount IGenericDal<CustomerAccount>.GetById(int id)
        {
            throw new NotImplementedException();
        }

        List<CustomerAccount> IGenericDal<CustomerAccount>.GetList()
        {
            throw new NotImplementedException();
        }
    }
}
