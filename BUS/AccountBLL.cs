using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Entities;
namespace BUS
{
    public class AccountBLL
    {
        private AccountDAL _accountRE;
        public AccountBLL()
        {
            _accountRE = new AccountDAL();
        }
        
        public List<Account> GetAllAccounts()
        {
            return _accountRE.GetAllAccounts();
        }
    }
}
